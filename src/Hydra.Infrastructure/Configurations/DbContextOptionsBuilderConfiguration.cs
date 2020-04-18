using Microsoft.EntityFrameworkCore;

namespace Hydra.Infrastructure.Configurations
{
    public static class DbContextOptionsBuilderConfiguration
    {
        public static DbContextOptionsBuilder UseSqlServerProvider(this DbContextOptionsBuilder builder, string connectionString, string migrationAssembly) =>
            builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationAssembly));
    }
}