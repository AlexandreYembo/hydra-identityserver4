namespace Hydra.IdentityServer.Data
{
    public class MigrationCore
    {
        public void Run(){
              "dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb".Bash();
              "dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb".Bash();
              "dotnet ef migrations add InitialIdentityServerApplicationDbMigration -c ApplicationDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb ".Bash();
        }
    }
}