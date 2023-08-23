# ShipIt Inventory Management

## Setup Instructions
Open the project in VSCode.
VSCode should automatically set up and install everything you'll need apart from the database connection!

### Setting up the Database.
Create 2 new postgres databases - one for the main program and one for our test database.
Ask a team member for a dump of the production databases to create and populate your tables.

Then for each of the projects, add a `.env` file at the root of the project.
That file should contain a property named `POSTGRES_CONNECTION_STRING`.
It should look something like this:
```
POSTGRES_CONNECTION_STRING=Server=127.0.0.1;Port=5432;Database=Shipit;User Id=shipit; Password=shipit;
```


## Running The API
Once set up, simply run dotnet run in the ShipIt directory.

## Running The Testse ShipItTests directory.
To run the tests you should be able to run dotnet test in th

## Deploying to Production
TODO
