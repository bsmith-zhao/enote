set dst="C:\prj\EncryptNote\1.1.1"
echo %dst%

mkdir %dst%

del /Q /S %dst%

xcopy "P:\EncryptNote\app" %dst% /e /y /exclude:exclude.txt

pause