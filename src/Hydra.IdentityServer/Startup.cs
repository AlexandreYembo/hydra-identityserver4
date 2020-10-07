using System;
using System.Linq;
using Hydra.IdentityServer.Data;
using Hydra.IdentityServer.Extensions;
using Hydra.IdentityServer.Helpers;
using Hydra.IdentityServer.Seeds;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hydra.IdentityServer
{
    public class Startup
    {
        public IConfiguration _configuration;

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            // if(hostEnvironment.IsDevelopment())
            // {
            //     builder.AddUserSecrets<Startup>();
            // }

            _configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcConfiguration();
            // configures IIS out-of-proc settings (see https://github.com/aspnet/AspNetCore/issues/14882)

            services.IISConfiguration();

            services.AddIdentityConfiguration(_configuration);

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddApplicationDataBase(_configuration);

            services.AddAuthentications(_configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAppConfiguration(env);
            
            //Read configuration Contexts
            bool seedConfig = _configuration.GetSection("configurationContext").GetValue<bool>("seedDb");
           
            //Read application Contexts
            bool seedApp = _configuration.GetSection("applicationContext").GetValue<bool>("seedDb");
           
           
            if(seedConfig)
                app.ConfigurationSeedData();
            
            if(seedApp)
                app.AppicationSeedData();
        }
    }
}