### Package configuration and tags 
- `Solution` >  `.template.config` > `template.json`. 

--- 

### Template commands 
Open PowerShell in `TemplatePack.csproj` folder. 
- Local installation.  
  `dotnet new -i .` 
- Local removal.  
  `dotnet new -u` or  
  `dotnet new -u .` or  
  `dotnet new --uninstall CoreSharp.Templates.Blazor.Server`
- Create nuget package.  
  `dotnet pack -c Release .\TemplatePack.csproj -o .\artifacts` 
- Test nuget package.  
  `dotnet new -i .\Artifacts\CoreSharp.Templates.Blazor.Server.5.0.0.nupkg` 
- Install nuget package. 
  `dotnet new --install CoreSharp.Templates.Blazor.Server` 
- Uninstall nuget package.
  `dotnet new --uninstall CoreSharp.Templates.Blazor.Server` 
- Use nuget package. 
  `dotnet new clean-blazor-server --name {YourProjectName}` 
--- 