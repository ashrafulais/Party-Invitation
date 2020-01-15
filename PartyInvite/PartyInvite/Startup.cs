using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PartyInvite.Data;
using PartyInvite.Data.Interfaces;
using PartyInvite.Data.Repositories;
using PartyInvite.Data.Services;

namespace PartyInvite
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
            string connection, migration;
            connection = Configuration.GetConnectionString("DefaultConnection");
            migration = typeof(Startup).Assembly.FullName;

            services.AddTransient<PartyContext>( s=> new PartyContext(
                connection, migration));
            services.AddDbContext<PartyContext>(s => s.UseSqlServer(
                connection, m=>m.MigrationsAssembly(migration)));

            services.AddTransient<IGreetingsService, GreetingsService>();

            services.AddTransient<IGuestResponseRepo, GuestResponseRepo>()
                .AddTransient<IGuestResponseService, GuestResponseService>();

            services.AddTransient<IUnitofwork>(
                x=> new Unitofwork(connection, migration));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
