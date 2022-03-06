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
  `dotnet new --uninstall CoreSharp.CleanStructure.Blazor`
- Create nuget package.  
  `dotnet pack .\TemplatePack.csproj -o .\Artifacts` 
- Test nuget package.  
  `dotnet new -i .\Artifacts\CoreSharp.CleanStructure.Blazor.5.0.0.nupkg` 
- Install nuget package. 
  `dotnet new --install CoreSharp.CleanStructure.Blazor` 
- Uninstall nuget package.
  `dotnet new --install CoreSharp.CleanStructure.Blazor` 
- Use nuget package. 
  `dotnet new clean-blazor --name {YourProjectName}` 
--- 