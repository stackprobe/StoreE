CALL C:\Factory\SetEnv.bat
CALL Clean.bat
cx **
IF ERRORLEVEL 1 START *[BUILD-ERROR]

acp Petra20200001\Program.exe out\*P.exe
xcp doc out

C:\Factory\SubTools\zip.exe /PE- /O out *P
