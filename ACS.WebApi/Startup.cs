using ACS.WebApi.BaseDados;
using ACS.WebApi.BaseDados.Repositorios;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.Negocio;
using ACS.WebApi.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ACS.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public IConfiguration _Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<Contexto>(opc =>
                    opc.UseSqlServer(_Configuration.GetConnectionString("Conexao"),
                    x => x.MigrationsAssembly("ACS.WebApi.BaseDados")));
            
            InjecaoDependenciaNegocio.Injetar(services);

            InjecaoDependenciaRepositorio.Injetar(services);

            //Criptografia por injecao de dependencia, caso necessario apenas trocar a criptografia
            services.AddScoped<ICrypto, MD5Crypto>();


            //especifica o esquema usado para autenticacao do tipo Bearer
            // e 
            //define configurações como chave,algoritmo,validade, data expiracao...
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "ACS.tcc.com",
                    ValidAudience = "ACS.tcc.com",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_Configuration["ChaveSecreta"]))
                };

                //options.Events = new JwtBearerEvents
                //{
                //    OnAuthenticationFailed = context =>
                //    {
                //        return ;
                //    },
                //    OnTokenValidated = context =>
                //    {
                //        Console.WriteLine("Toekn válido...: " + context.SecurityToken);
                //        return Task.CompletedTask;
                //    }
                //};
            });
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
                }
                else
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
            app.UseAuthentication();
        }
    }
}
