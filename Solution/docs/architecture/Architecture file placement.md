### Core > Application 
- Repository interface > `./Repositories` 
- UnitOfWork interface > `./Repositories` 
- Dto models >`./Dto`  
- Mappings > `./Mappings` 
- MediatR query >`./Features/{DomainModel}/Queries` 
- MediatR command > `./Features/{DomainModel}/Commands` 
- MediatR handlers > Same file with their corresponding query/command. Also make them `internal`.

--- 

### Core > Domain 
- Domain models > `./Entities` 

--- 
 
### Infrastructure > Infrastructure 
- DbContext > `./Context` 
- Entity type configurations > `./EntityConfigurations` 
- Migrations (automatic) >`./Migrations` 
- Repository implementation `./Repositories` 
- UnitOfWork implementation `./Repositories` 

--- 

### Infrastructure > Infrastructure.Shared 

--- 

### Web > Client > Client 
- Routes.  
  - For each new route crete > `Feature` > `Page` > `PageContent`. 
  - Control routing logic in `Page`. Design layout in `PageContent`. 
--- 
 
### Web > Server > Server 
- API Controller > `./Controllers` 

--- 
