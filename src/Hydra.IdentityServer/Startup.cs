using System;
using System.Linq;
using Hydra.IdentityServer.Data;
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

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // configures IIS out-of-proc settings (see https://github.com/aspnet/AspNetCore/issues/14882)
            services.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });

            // configures IIS in-proc settings
            services.Configure<IISServerOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

              var builder = services.AddIdentityServer()
                .AddTestUsers(TestUsers.Users)
                .AddConfigurationDatabase(_configuration)
                .AddAspNetIdentity<ApplicationUser>();;

            services.AddApplicationDataBase(_configuration);

            builder.AddDeveloperSigningCredential();
            services.AddAuthentications(_configuration);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title="Hydra Authentication Identity",
                    Description = "This api wil be used to authenticate throw the Hydra APIS",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact{ Name = "Alexandre Yembo"},
                    License = new Microsoft.OpenApi.Models.OpenApiLicense{ Name = "MIT", Url = new Uri("https://opensource.org/license/MIT")}
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

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