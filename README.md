# Test

## Excercise

Create a project in asp.net Core MVC (C#) following the DDD pattern.
The project will not have authentication or authorization, only a simple CRUD to register people with name, surname, DNI and phone. The name, surname and DNI will be mandatory. The pattern must include validation for the DNI, so that if it is entered incorrectly, the form will not be sent.
The list will be simple, a table with name, surname and DNI, and the actions to edit and delete.
The persistence will be with EF Core). Preferably Sqlite, although you can also use in-memory persistence.
Use, whenever you can, the asynchronous methods of EF for the operations with the database.
Make the tests you consider necessary to cover the logic of the application.
Feel free to make decisions on implementation, just provide a reason for doing so in a readme or similar.

## ARCH

- Client: Mvc aplication who renders the view with Razor pages.
- Core/Domain: Structure the Interfaces for defining the implementation on the Infrastructure Layer
- Infrastructure: Implementation for the logic that will modify the bd
- The Db for this application is In memory with 2 seed "people" that will be generated each time on the excecution.

## For run this application:

- Be ensured to have .NET 5 SDK to run it.
- Restore the Nugget Packages
- Run as debug.

Tests:
I found some problems to test the controllers actions.
