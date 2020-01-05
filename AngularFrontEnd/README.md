#This is a sample project of a web application to register flight plans. Some terms and database tables are in portuguese to follow the terms from the requirement of the test.

- Frontend in Angular 7 with Angular Material
- Backend in Aspnet Core 2.2 Web Api
- Authentication with JWT 

- Backend Details:
-- Project CrossCutting.IoC = Ioc Container configuration for the DI using the native services from dotnet core DI
-- Project Common: ViewModels, Extensions and NLog as the log tool
--- I used the AutoMapper for the mapping of the ViewModels and Domain Entities. I also created an extension class to make generic the logic to project  the contents of a list of domain entities to a list of the corresponding ViewModels.
--- I used NLog to log errors from the application, using also a global filter for that.
-- Project Data: Dapper ORM and repositories using Dapper resources (was used before, but now the application is set for Entity Framework)
-- Project Domain: The domain entities from the application
-- Project Model: Entity Framework ORM configuration and the domain entities set for EF usage
-- Project Repository: Generic repository for EF entities with Unit of Work configuration
-- Project Service: Services layer for the application (using the EF)
-- Project Webapplication: The web application

Database
- I used the SQL Server 2016 Developer edition
- There is a script available to create the database
