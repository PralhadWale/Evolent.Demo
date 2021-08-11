# Evolent Health - Demo Project
 Evolent Demo Project - Run Projct 

Project Architecture

1) Evolent.Demo.Data - Repository Layer
   Repository Later which is having Database entity model & repositories whill will be refered by higher domain layer to connet with database.

2) Evolent.Demo.Domain - Service/Domain Layer
   This class libarary will all logic related to domain & it's a middle layer in application which uses data layer to connect with db & is having all domain logic in it.
   This project is used in API Project using Repository Pattern.

3) Evolent.Demo.Web - API Project
   This the API project which will consume by front end application.
   All ef core repositores are registered in startup file
   SerilogMiddleware added for error logging purpose.
   
4) Evolent.Demo.UI :
   Angular Front end application for contact management

Evolent Health Project - Run Projct 
Development Enviornment -: .Net Core 3.1 , Angular , IDE (VS2019 , VS Code)
1) Create 'ContactDemo' DB & Execute Script From Folder 'DBScript' to create database table..
2) Open API Project in Visual Studio & Change Connection string 'DefaultConnection'  in 'appsetting.json' file from 'Evolent.Demo.Web' project
3) Open UI Project in Visual Studio Code , Open Terminal & run ng serve.
