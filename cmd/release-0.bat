set dst="C:\prj\EncryptNote\0"
echo %dst%

mkdir %dst%

del /Q /S %dst%

xcopy "P:\EncryptNote\app" %dst% /e /y /exclude:exclude.txt

pause