using ACS.WebApi.BaseDados.Repositorios;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACS.WebApi.BaseDados
{
    public static class InjecaoDependenciaRepositorio
    {
        public static void Injetar(IServiceCollection services)
        {
            services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
            services.AddScoped<IMedicaoRepositorio, MedicaoRepositorio>();
            services.AddScoped<IPacienteRemedioRepositorio, PacienteRemedioRepositorio>();
            services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();
            services.AddScoped<IPerguntaRepositorio, PerguntaRepositorio>();
            services.AddScoped<IRemedioRepositorio, RemedioRepositorio>();
            services.AddScoped<IRespostaRepositorio, RespostaRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        }

    }
}
