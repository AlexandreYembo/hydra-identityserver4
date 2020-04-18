using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Hydra.IdentityServer.Seeds
{
    public static class ConfigurationDBSeed
    {
        public static void ConfigurationSeedData(this IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();

                if(!context.Clients.Any())
                {
                    foreach (var client in Clients.Get())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any()) 
                {
                    foreach (var resource in Config.GetIdentityResources()) 
                    {
                       context.IdentityResources.Add(resource.ToEntity()); 
                    }
                    context.SaveChanges(); 
                }
                
                if (!context.ApiResources.Any()) 
                {
                    foreach (var resource in ApiResources.Get()) 
                    {
                        context.ApiResources.Add(resource.ToEntity()); 
                    }
                    context.SaveChanges(); 
                }
            }
        }
    }
}