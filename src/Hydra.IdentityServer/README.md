# Hydra Identity Server 4
This project implements Identity Server 4 to connect an client and give access by Authentication/Authorization.

### Adding Migrations
```dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb```
```dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb```
