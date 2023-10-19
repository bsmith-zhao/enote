using enote.util.ext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using util;
using util.crypt;
using util.ext;

namespace enote
{
    public partial class NoteForm : Form
    {
        public string notePath;

        string AppName => Application.ProductName;
        string AppVersion => Application.ProductVersion;

        const string NoteFilter = "Encrypt Note (*.enote)|*.enote|All Files (*.*)|*.*";

        string confPath => $"{this.appTrunk()}.conf";
        AppConf conf = new AppConf();

        bool modify = false;

        byte[] pwdEncKey = new byte[32].aesRnd();
        byte[] pwdCipher;
        byte[] getPwd() => pwdCipher.winTryDec(pwdEncKey);
        void updatePwd(byte[] pwd) 
            => pwdCipher = pwd.winEnc(pwdEncKey);

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(confPath))
                this.trydo(() =>
                    conf = File.ReadAllText(confPath).obj<AppConf>(),
                    err => $"Error on load conf [{confPath}]\r\n{err.Message}".dlgAlert());

            updateTitle();

            if (null != notePath && !openNote(notePath))
                this.Close();
        }

        public NoteForm()
        {
            InitializeComponent();

            infoUI.logToMeAsync();

            topBar.fixBorderBug();
            leftBar.fixBorderBug();

            backColorBtn.Paint += BackColorBtn_Paint;
            foreColorBtn.Paint += ForeColorBtn_Paint;

            this.KeyDown += MainForm_KeyDown;
            this.FormClosing += MainForm_FormClosing;

            wordWrapBtn.Checked = !noteUI.WordWrap;

            noteUI.HideSelection = false;
            noteUI.EnableAutoDragDrop = true;
            noteUI.SelectionChanged += noteUI_SelectionChanged;
            noteUI.TextChanged += noteUI_TextChanged;
            noteUI.KeyDown += NoteUI_KeyDown;

            infoUI.HideSelection = false;

            leftBar.Padding = new Padding(2);
            foreach (ToolStripItem btn in leftBar.Items)
            {
                btn.AutoSize = false;
                btn.DisplayStyle = ToolStripItemDisplayStyle.Image;
                btn.Size = new Size(50, 50);
            }

            infoSplit.MouseDoubleClick += (s, e) => 
            {
                infoUI.Width = 0;
                infoUI.Rtf = "";
            };
        }

        bool getPasteImages(out List<string> files)
        {
            files = null;
            if (Clipboard.ContainsImage())
                return true;

            foreach (string path in Clipboard.GetFileDropList())
            {
                if (conf.isImage(path))
                    (files = files ?? new List<string>()).Add(path);
            }
            return files?.Count > 0;
        }

        private void NoteUI_KeyDown(object sender, KeyEventArgs e)
        {
            this.trydo(() => noteKeyDown(e));
        }

        void pasteImage(string path)
        {
            using (var img = Clipboard.GetImage())
            {
                if (img != null)
                {
                    var rtf = getImageRtf(img, path);
                    noteUI.SelectedRtf = rtf;
                    noteUI.SelectedText = "\r\n";
                }
            }
            Clipboard.Clear();
        }

        void pasteImages(List<string> files)
        {
            if (files == null)
                pasteImage(null);
            else
            {
                files.Reverse();
                foreach (var path in files)
                {
                    using (var img = Image.FromFile(path))
                    {
                        Clipboard.SetImage(img);
                    }
                    pasteImage(path);
                }
            }
        }

        void noteKeyDown(KeyEventArgs e)
        {
            if (e.CtrlV())
            {
                e.Handled = true;
                paste();
            }
        }

        void paste()
        {
            if (getPasteImages(out var files))
                pasteImages(files);
            else
                noteUI.Paste();
        }

        string getImageRtf(Image img, string path)
        {
            var DpiX = this.DeviceDpi;
            var DpiY = this.DeviceDpi;

            var buff = new BytesListBuffer
            {
                BlockSize = 256.kb(),
            };

            bool exceed = false;
            buff.BeforeWrite = (cnt) =>
            {
                if (buff.Position + cnt > conf.imageLimit())
                    exceed = true;
                return !exceed;
            };

            img.convToJpeg(buff, conf.getJpgQuality());

            if (exceed)
            {
                if (path == null)
                    throw new Exception("image in clipboard is too large!!");
                else
                    throw new Exception($"image in [{path}] is too large!!");
            }

            var picw = img.Width * 2540 / DpiX;
            var pich = img.Height * 2540 / DpiY;
            var picwgoal = img.Width * 1440 / DpiX;
            var pichgoal = img.Height * 1440 / DpiY;
            var head = @"{\rtf1{\pict\<fmt>blip\picw<w>\pich<h>\picwgoal<wg>\pichgoal<hg> "
                        .Replace("<w>", $"{picw}")
                        .Replace("<h>", $"{pich}")
                        .Replace("<wg>", $"{picwgoal}")
                        .Replace("<hg>", $"{pichgoal}")
                        .Replace("<fmt>", "jpeg")
                        ;
            var tail = "}}";

            var chars = new char[head.Length + buff.Length * 2 + tail.Length];
            chars.paste(0, head)
                .paste(chars.Length - tail.Length, tail);

            buff.Blocks.hexLow(buff.Length.i32(), chars, head.Length);

            return new string(chars);
        }

        private void noteUI_TextChanged(object sender, EventArgs e)
        {
            updateModify(true);
        }

        private void noteUI_SelectionChanged(object sender, EventArgs e)
        {
            updateFormat();
        }

        void updateFormat()
        {
            backColorBtn.Invalidate();
            foreColorBtn.Invalidate();
            if (selFont.Name != fontBtn.Font.Name
                || selFont.Style != fontBtn.Font.Style)
            {
                fontBtn.Font = new Font(selFont.FontFamily, fontBtn.Font.Size, selFont.Style);
                fontBtn.Text = selFont.Name;
            }
        }

        Color backColor
        {
            get => noteUI.SelectionBackColor;
            set
            {
                noteUI.SelectionBackColor = value;
                updateFormat();
            }
        }

        Color foreColor
        {
            get => noteUI.SelectionColor;
            set
            {
                noteUI.SelectionColor = value;
                updateFormat();
            }
        }

        Font selFont
        {
            get => noteUI.SelectionFont ?? noteUI.Font ?? this.Font;
            set
            {
                noteUI.SelectionFont = value;
                updateFormat();
            }
        }

        void drawColorBar(Graphics g, Color c, int width)
        {
            using (var br = new SolidBrush(c))
            {
                g.FillRectangle(br, width/2-15, 28, 30, 5);
            }
        }

        private void ForeColorBtn_Paint(object sender, PaintEventArgs e)
        {
            drawColorBar(e.Graphics, foreColor, foreColorBtn.Width);
        }

        private void BackColorBtn_Paint(object sender, PaintEventArgs e)
        {
            drawColorBar(e.Graphics, backColor, backColorBtn.Width);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            save();
        }

        void save()
        {
            var path = notePath ?? Dialog.saveFile(NoteFilter);
            if (null == path)
                return;

            saveNote(path);
        }

        private void setPwdBtn_Click(object sender, EventArgs e)
        {
            var pwd = setNewPwd(notePath);
            if (pwd == null)
                return;

            if (notePath != null)
                save();
        }

        void updateModify(bool modify)
        {
            this.modify = modify;
            updateTitle();
        }

        private void saveAsBtn_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        void saveAs()
        {
            if (!Dialog.saveFile(out var path, NoteFilter))
                return;

            saveNote(path);
        }

        void updateTitle()
        {
            var mark = modify ? "*" : "";
            this.Text = $"{AppName} {AppVersion} - {noteUI.TextLength}{mark} - [{notePath ?? "none"}]";
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            open();
        }

        void open()
        {
            if (modify && !"Open will drop changes, are you sure?".confirm())
                return;

            if (!Dialog.pickFile(out var path, NoteFilter))
                return;

            openNote(path);
        }

        bool verifyPwd(string msg, Action<byte[]> verify)
        {
            return new PwdDialog()
                .dark()
                .verifyPwd(msg, pwd => verify(pwd));
        }

        byte[] setNewPwd(string path)
        {
            var msg = "Set new pwd";
            if (null != path)
                msg = $"Set pwd for [{path}]";

            var pwd = new PwdDialog()
                .dark()
                .setNewPwd(msg);

            if (null != pwd)
                updatePwd(pwd);

            return pwd;
        }

        bool openNote(string path)
        {
            bool success = false;
            this.trydo(() => 
            {
                byte[] pwd = null;
                var data = readData(path, ref pwd);
                if (data == null)
                    return;
                data.Position = 0;

                noteUI.loadRtf(data);

                updatePwd(pwd);
                notePath = path;
                updateModify(false);

                success = true;
            });
            return success;
        }

        Stream readData(string path, ref byte[] pwd)
        {
            using (var fin = File.OpenRead(path))
            {
                var note = new NoteFile().open(fin);

                if (pwd != null)
                    note.verify(pwd);
                else if (!new PwdDialog().dark()
                    .verifyPwd($"Input pwd for [{path}]", note.verify))
                    return null;
                pwd = note.pwd;

                var data = new BytesListBuffer { BlockSize = note.block };
                using (var rs = note.read(fin))
                {
                    rs.CopyTo(data, note.block);
                    return data;
                }
            }
        }

        void saveNote(string path)
        {
            var pwd = getPwd() ?? setNewPwd(path);
            if (null == pwd)
                return;

            this.trydo(() =>
            {
                path.bakSave(fout =>
                {
                    var ws = new NoteFile
                    {
                        conf = conf,
                        pwd = pwd,
                    }.create(fout);

                    using (ws)
                    {
                        noteUI.SaveFile(ws, RichTextBoxStreamType.RichText);
                    }
                });

                notePath = path;
                updateModify(false);

                verifyNote(path, pwd, conf.ShowVerifyRtf);
            });
        }

        //void saveNote(string path)
        //{
        //    var pwd = getPwd() ?? setNewPwd(path);
        //    if (null == pwd)
        //        return;

        //    this.trydo(() => 
        //    {
        //        var enc = new CascadeCrypt
        //        {
        //            pwd = pwd,
        //            conf = conf,
        //        }.create();
        //        var specData = enc.spec.json().utf8();
        //        var headData = $"{NoteID}{NoteVersion}&{specData.Length.hex(6)}".utf8();

        //        path.bakSave(fout =>
        //        {
        //            fout.write(headData);
        //            fout.write(specData);

        //            using (var wrt = enc.encrypt(fout))
        //            {
        //                noteUI.SaveFile(wrt, RichTextBoxStreamType.RichText);
        //            }
        //        });

        //        spec = enc.spec;
        //        notePath = path;
        //        updateModify(false);

        //        verifyNote(path, pwd, conf.ShowVerifyRtf);
        //    });
        //}

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.CtrlS())
            {
                if (e.Shift)
                    saveAs();
                else if (modify)
                    save();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!modify || Dialog.confirm("Close will drop changes, are you sure?"))
                return;

            e.Cancel = true;
        }

        private void noWrapBtn_Click(object sender, EventArgs e)
        {
            noteUI.WordWrap = !wordWrapBtn.Checked;
        }

        private void setupBtn_Click(object sender, EventArgs e)
        {
            var dlg = new OptionDialog
            {
                path = confPath,
                conf = conf
            }.dark();
            dlg.ShowDialog();

            conf = dlg.conf;
        }

        private void fontBtn_Click(object sender, EventArgs e)
        {
            if (!this.pickFont(out var font, selFont))
                return;

            selFont = font;
        }

        private void backColorBtn_Click(object sender, EventArgs e)
        {
            if (!this.pickColor(out var color, backColor))
                return;

            backColor = color;
        }

        private void foreColorBtn_Click(object sender, EventArgs e)
        {
            if (!this.pickColor(out var color, foreColor))
                return;

            foreColor = color;
        }

        private void pasteBtn_Click(object sender, EventArgs e)
        {
            this.trydo(paste);
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            noteUI.Copy();
        }

        private void cutBtn_Click(object sender, EventArgs e)
        {
            noteUI.Cut();
        }

        private void viewRtfBtn_Click(object sender, EventArgs e)
        {
            infoUI.Rtf = noteUI.SelectedRtf;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            if (modify && !"Create new will drop changes, are you sure?".confirm())
                return;

            noteUI.Rtf = "";
            notePath = null;
            updateModify(false);
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            if (notePath == null)
                return;

            this.trydo(()=> 
            {
                verifyNote(notePath, null);
            });
        }

        void verifyNote(string path, byte[] pwd, bool showRtf = true)
        {
            var data = readData(path, ref pwd);
            if (data == null)
                return;
            data.Position = 0;

            var verify = new VerifyWrite { data = data };
            noteUI.saveRtf(verify);
            verify.Flush();

            if (!verify.NoError)
                throw new Exception(verify.error);

            if (showRtf)
            {
                data.Position = 0;
                infoUI.loadRtf(data);
            }
        }

        private void viewCodeBtn_Click(object sender, EventArgs e)
        {
            var rtf = noteUI.SelectedRtf;

            infoUI.Text = $"<rtf chars={rtf.Length}, image bytes={(rtf.Length/2).i64().byteSize()}, rtf bytes={(rtf.Length*2).i64().byteSize()}>";
            infoUI.SelectedText = rtf;
        }
    }
}
