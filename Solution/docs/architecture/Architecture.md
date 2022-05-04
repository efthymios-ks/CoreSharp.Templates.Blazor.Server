### Structure 
Current architecture consists of four layers.  
1. Web _(presentation projects that user access, like web api, UI etc.)_. 
2. Infrastructure _(anything that communicates out of your app's process and data access implementations, like EF Core layers, authentication etc.)_. 
3. Application _(application specific services and interfaces)_. 
4. Domain _(application specific entities and types)_. 

### Accessibility 
1. `Domain` doesn't depend on anything. 
2. `Application` > `Domain`. 
3. `Infrastructure` > `Application`, `Domain`. 
4. `Client.Infrastructure` > `Application`. 
4. `Client` > `Client.Infrastruture`. 
5. `Server` > `Application`, `Infrastructure`. 
