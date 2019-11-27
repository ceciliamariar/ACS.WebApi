using ACS.WebApi.BaseDados;
using ACS.WebApi.Negocio;
using ACS.WebApi.Util;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<Contexto>(opc =>
                    opc.UseSqlServer(_Configuration.GetConnectionString("Conexao"),
                    x => x.MigrationsAssembly("ACS.WebApi.BaseDados")));

            InjecaoDependenciaNegocio.Injetar(services);

            InjecaoDependenciaRepositorio.Injetar(services);

            //Criptografia por injecao de dependencia, caso necessario apenas trocar a criptografia
            services.AddScoped<ICrypto, MD5Crypto>();

            var SecaoConfiguracao = _Configuration.GetSection("Configuracoes");
            services.Configure<Configuracoes>(SecaoConfiguracao);

            var configuracao = SecaoConfiguracao.Get<Configuracoes>();

            //especifica o esquema usado para autenticacao do tipo Bearer
            // e 
            //define configurações como chave,algoritmo,validade, data expiracao...
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = "ACS.tcc.com",
            //        ValidAudience = "ACS.tcc.com",
            //        IssuerSigningKey = new SymmetricSecurityKey(
            //            Encoding.UTF8.GetBytes(_Configuration["ChaveSecreta"]))
            //    };
            //    options.Events = new JwtBearerEvents()
            //    {
            //        OnTokenValidated = cotext =>
            //        {
            //            return Task.CompletedTask;
            //        },
            //        OnAuthenticationFailed = cotext =>
            //        {
            //            return Task.CompletedTask;
            //        },
            //    };

            //});

            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(b=>
            {
                b.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuracao.Emissor ,
                    ValidAudience = configuracao.ValidoEm,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuracao.ChaveSecreta))
                };

            }
            );
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Agente Comunitário de Saúde - Web API",
                    Version = "v1",
                    Description = "ASP.NET Core Web API para o monitoramento da saúde de pacientes",
                    Contact = new Contact
                    {
                        Name = "Maria Cecília Pereira Rodrigues",
                        Email = "cecilia.mariar2@gmail.com"
                    }
                });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition(
                    "Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Infore o token no seguinte padrão 'Bearer ' + token'",
                        Name = "Authorization",
                        Type = "apiKey"
                    });

                c.AddSecurityRequirement(security);
            });

            services.AddAutoMapper( typeof(MapperEntrada), typeof(MapperSaida));

        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors(a => a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();
            app.UseMvc();
            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }

    }
}
