using System;
using System.IO;
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
using SSAApp.Web.Domain.Core;
using SSAApp.Web.Domain.Interfaces.Repositories;
using SSAApp.Web.Domain.Interfaces.Services;
using SSAApp.Web.Infraestructure.Repositories;
using Microsoft.OpenApi.Models;
using SSAApp.Web.Services.Interfaces;
using SSAApp.Web.Services.Services;

namespace SSAApp.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string xmlPath = Path.Combine(basePath, "SSAApp.Web.xml");

            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc(name: "v1", new OpenApiInfo() { Title = "SSAApp API", Version = "v1" });
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerGenNewtonsoftSupport();

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "SSAApp Api v1");
                //c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "defaultv1",
                    pattern: "api/v1/{controller}/{id?}",
                    defaults: "api/v1/Status/");
            });
        }
    }
}