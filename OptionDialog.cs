using System;
using System.Drawing;
using System.Windows.Forms;
using util;
using util.ext;
using util.prop;

namespace enote
{
    public partial class OptionDialog : Form
    {
        public string path;
        public AppConf conf
        {
            get => propUI.SelectedObject as AppConf;
            set => propUI.SelectedObject = value;
        }

        private void OptionDialog_Load(object sender, EventArgs e)
        {
            splitUI.BackColor = Color.FromArgb(27, 27, 27);
            descUI.BackColor = Color.FromArgb(25, 25, 25);
        }

        public OptionDialog()
        {
            InitializeComponent();

            toolbar.fixBorderBug();

            propUI.editAndLimit(e => saveConf(conf));
        }

        void saveConf(AppConf conf)
        {
            this.trydo(() => 
            {
                conf = conf ?? new AppConf();
                path.bakSaveText(conf.jsonIndent());
                this.conf = conf;
            });
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            if (!"Sure to reset conf?".confirm())
                return;

            saveConf(null);
        }

        private void openDirBtn_Click(object sender, EventArgs e)
        {
            path.locDir().dirOpen();
        }
    }
}
