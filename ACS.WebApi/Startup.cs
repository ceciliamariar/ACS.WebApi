using ACS.WebApi.BaseDados;
using ACS.WebApi.BaseDados.Repositorios;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.Negocio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ACS.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<Contexto>(opc =>
                    opc.UseSqlServer(Configuration.GetConnectionString("Conexao"),
                    x => x.MigrationsAssembly("ACS.WebApi.BaseDados")));



            services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();




            services.AddSwaggerDocument(opcoes =>
           {
               opcoes.PostProcess = documento => { documento.Info.Title = "ACS Api"; };
                //opcoes.OperationProcesso
            }
            );

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            app.UseSwaggerUi3(config => config.TransformToExternalPath = (internalUIRoute, request) =>

            {
                if (internalUIRoute.StartsWith("/") && !internalUIRoute.StartsWith(request.PathBase))
                {
                    return request.PathBase + internalUIRoute;
                }else
                {
                    return internalUIRoute;
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
