# KBFlow
Simple terminal task creation tool for https://kanbanflow.com/

Usage:
1. Add valid KBFlow token with user-secrets:
```
dotnet user-secrets init
dotnet user-secrets set "api-token" "your-KBFlow-api-token"
```

2. After making changes publish application as a self-contained app:
```
dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishReadyToRun=true /p:PublishSingleFile=true
```

3. Move /KBFlow/KBFlow/bin/Release/net7.0/osx-arm64/publish/KBFlow file to /usr/local/bin:
```
sudo mv KBFlow /usr/local/bin
```

4. Optionally add alias:
```
alias ll='KBFlow'
```

5. Now it can be used with ll command:
```
ll Some new task
```
