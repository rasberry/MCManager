@echo off
net use \\HACKBERRY\Ajia\temp\mcmanager
mkdir \\HACKBERRY\Ajia\temp\mcmanager\bin
mkdir \\HACKBERRY\Ajia\temp\mcmanager\Static
copy /Y bin\Release\EasySgml.dll \\HACKBERRY\Ajia\temp\mcmanager\bin
copy /Y bin\Release\MCManager.dll \\HACKBERRY\Ajia\temp\mcmanager\bin
copy /Y Static\*.* \\HACKBERRY\Ajia\temp\mcmanager\Static
copy /Y web.config \\HACKBERRY\Ajia\temp\mcmanager
goto :EOF

::anders@hackberry:/var/www$
::sudo /etc/init.d/fastcgi-mono stop; rm -r mcmanager; mv /ajia/temp/mcmanager .; sudo /etc/init.d/fastcgi-mono start
