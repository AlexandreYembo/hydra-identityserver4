using System.Reflection;
using Hydra.IdentityServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.IdentityServer
{
    public static class DataBase
    {
      /// <summary>
      /// Create Migration for Configuration Context Data base  
      /// </summary>
      /// <param name="services"></param>
      /// <param name="connectionString"></param>
      /// <param name="migrationAssembly"></param>
      ///MigrationsAssembly -> is used to inform Entity Framework that the host project will contain the migrations code. 
      ///This is necessary since the host project is in a different assembly than the one that contains the DbContext classes
      /// <returns></returns>
        public static IIdentityServerBuilder AddConfigurationDatabase(this IIdentityServerBuilder services, IConfiguration configuration)
        {
            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            string connectionString = configuration.GetSection("configurationContext").GetValue<string>("dbConnection");
            string provider = configuration.GetSection("configurationContext").GetValue<string>("dbprovider");

            //You have to install the SQL Server package: "Microsoft.EntityFrameworkCore.SqlServer"
            // It will be required also for data base migrations.
            if(provider == "SQL_SERVER"){
                services.AddConfigurationStore(options => 
                    options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationAssembly))
                )
                .AddOperationalStore(options => 
                    options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationAssembly))
                );
            } 
            else if(provider == "MONGO_DB")
            {
                 //TODO: Implement mongo DB Context and Mongo Driver
            }

            return services;
        }

    /// <summary>
    /// Create Migration for application Context Data base
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
        public static IServiceCollection AddApplicationDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetSection("applicationContext").GetValue<string>("dbConnection");
            string provider = configuration.GetSection("applicationContext").GetValue<string>("dbprovider");

             if(provider == "SQL_SERVER")
             {
                 services.AddDbContext<ApplicationDbContext>(options => 
                    options.UseSqlServer(connectionString));
             }
             else if(provider == "MONGO_DB")
             {
                 //TODO: Implement mongo DB Context and Mongo Driver
             }

             return services;
        }
    }
}