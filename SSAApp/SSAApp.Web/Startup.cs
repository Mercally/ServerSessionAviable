using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SSAApp.Models;
using SSAApp.Web.Domain.Core;
using SSAApp.Web.Domain.Entities;
using SSAApp.Web.Domain.Interfaces.Repositories;
using SSAApp.Web.Domain.Interfaces.Services;
using SSAApp.Web.Infraestructure;
using SSAApp.Web.Infraestructure.Repositories;
using SSAApp.Web.Interfaces;
using SSAApp.Web.Services;
//using SSAApp.Web.Infraestructure.

namespace SSAApp.Web
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();
            services.AddSingleton<IItemRepository, ItemRepository>();

            // Capa de aplicacion
            services.AddSingleton<IServerAppService, ServerAppService>();
            services.AddSingleton<IServerStatusAppService, ServerStatusAppService>();

            // Capa de dominio
            services.AddSingleton<IServerService, ServerService>();
            services.AddSingleton<IServerStatusService, ServerStatusService>();

            // Capa de infraestructura
            services.AddSingleton<IServerRepository, ServerRepository>();
            services.AddSingleton<IServerStatusRepository, ServerStatusRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}