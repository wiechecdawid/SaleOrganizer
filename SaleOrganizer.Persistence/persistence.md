### migrations
dotnet ef migrations add <name> -c DataContext -s ../SaleOrganizer.API -o ./Migrations

### mifration script
dotnet ef migrations script -i -c DataContext -s ../SaleOrganizer.API -o ./script.sql

## identity migrations & update
dotnet ef migrations add <name> -c DataContext -o ./IdentityMigrations
dotnet ef database update -s ../SaleOrganizer.API