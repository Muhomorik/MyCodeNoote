#  #Update project to 1.1.
https://blogs.msdn.microsoft.com/dotnet/2016/11/16/announcing-net-core-1-1/

You can use the following substitutions to help you update project.json files that you want to move temporarily or permanently to .NET Core 1.1.

- Update the netcoreapp1.0 target framework to netcoreapp1.1.
- Update the Microsoft.NETCore.App package version from 1.0.x (for example, 1.0.0 or 1.0.1) to 1.1.0.

## project.json ##

    {
      "version": "1.0.0-*",
      "buildOptions": {
        "debugType": "portable",
        "emitEntryPoint": true
      },
      "dependencies": {},
      "frameworks": {
        "netcoreapp1.1": {
          "dependencies": {
            "Microsoft.NETCore.App": {
              "type": "platform",
              "version": "1.1.0"
            }
          },
          "imports": "dnxcore50"
        }
      }
    }
