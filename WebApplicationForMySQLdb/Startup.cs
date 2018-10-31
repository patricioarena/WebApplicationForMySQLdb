using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationForMySQLdb.Data;
using WebApplicationForMySQLdb.Models;
using WebApplicationForMySQLdb.Services;
using AppService.Interfaces;
using AppService.Class;

namespace WebApplicationForMySQLdb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("FirstConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication()
            #region 
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = Configuration["Google:ClientId"];
                    googleOptions.ClientSecret = Configuration["Google:ClientSecret"];
                })
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.ClientId = Configuration["Facebook:ClientID"];
                    facebookOptions.ClientSecret = Configuration["Facebook:ClientSecret"];
                })
                .AddMicrosoftAccount(microsoftOptions =>
                {
                    microsoftOptions.ClientId = Configuration["Microsoft:ClientID"];
                    microsoftOptions.ClientSecret = Configuration["Microsoft:ClientSecret"];
                })
                .AddLinkedIn(linkedInOptions =>
                {
                    linkedInOptions.ClientId = Configuration["LinkedIn:ClientID"];
                    linkedInOptions.ClientSecret = Configuration["LinkedIn:ClientSecret"];
                })
                .AddTwitch(twitchOptions =>
                {
                    twitchOptions.ClientId = Configuration["Twitch:ClientID"];
                    twitchOptions.ClientSecret = Configuration["Twitch:ClientSecret"];
                })
                ;

            #endregion
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IAppServices, AppServices>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
