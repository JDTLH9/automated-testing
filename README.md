# TestApi
RESTful API in .NET Core 1.1.1 (VS2017 .csproj project type) with Acceptance Test Project

## Install Instructions
* Install [.NET Core CLI](https://www.microsoft.com/net/download/core) OR [Visual Studio 2017](https://www.visualstudio.com/downloads/)
* Install [MongoDB Windows Installer](https://www.mongodb.com/download-center#community)
* Install the Mongod.exe as a Windows Service using the following command:

`[MongoDB Install Path]\mongod --dbpath="[MongoDB data file path]" --logpath="[MongoDB log file path]" --install`

* Install [NodeJS](https://git-scm.com/download/win)
* cd to src\TestApi.Client directory and run the command "npm install" 

For Browser tests it is advised to self-host as a Windows Service using the following 2 commands (Admin Command Prompt):

*Test Client*: `sc create [service name] binPath= "[path to executable]\TestApi.Client.exe"`

*Test API*: `sc create [service name] binPath= "[path to executable]\TestApi.exe"`