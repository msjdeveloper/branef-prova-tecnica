# company-system

## Project setup
```
docker-compose up -d
```

### Run migrations

Inside of folder "src"
```
dotnet ef migrations add InitialCreate -p CompanySystem.Infrastructure -s CompanySystem.API
dotnet ef database update -p CompanySystem.Infrastructure -s CompanySystem.API --connection "Server=localhost;Port=5433;Database=company-system;User Id=postgres;Password=postgres;"
```

### Run Projects
```
dotnet run
```
