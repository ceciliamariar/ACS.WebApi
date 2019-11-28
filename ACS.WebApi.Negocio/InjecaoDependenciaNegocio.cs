using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACS.WebApi.Negocio
{
    public static class InjecaoDependenciaNegocio
    {
        public static void Injetar(IServiceCollection services)
        {
            services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
            services.AddScoped<IAutenticacaoNegocio, AutenticacoNegocio>();
            services.AddScoped<ICriptografiaNegocio, CriptografiaNegocio>();
            services.AddScoped<IEnderecoNegocio, EnderecoNegocio>();
            services.AddScoped<IMedicaoNegocio, MedicaoNegocio>();
            //services.AddScoped<IPacienteRemedioNegocio, PacienteRemedioNegocio>();
            services.AddScoped<IPacienteNegocio, PacienteNegocio>();
            services.AddScoped<IPerguntaNegocio, PerguntaNegocio>();
            services.AddScoped<IRemedioNegocio, RemedioNegocio>();
            services.AddScoped<IRespostaNegocio, RespostaNegocio>();

        }

    }
}
