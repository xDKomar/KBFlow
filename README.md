# KBFlow
After changes publish application as self-contained:

dotnet publish -c Release -r osx-x64 --self-contained -p:PublishReadyToRun=true /p:PublishSingleFile=true

then move to /usr/local/bin:

sudo mv KBFlow /usr/local/bin
