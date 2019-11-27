using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using AutoMapper;

namespace ACS.WebApi.Negocio
{
    public class MapperEntrada : Profile
    {
        public MapperEntrada()
        {
            CreateMap<UsuarioEntrada, Usuario>().ReverseMap();
            CreateMap<PacienteEntrada, Paciente>().ReverseMap();
            CreateMap<EnderecoEntrada, Endereco>().ReverseMap();
            CreateMap<MedicaoEntrada, Medicao>().ReverseMap();
            CreateMap<PerguntaEntrada, Pergunta>().ReverseMap();
            CreateMap<RemedioEntrada, Remedio>().ReverseMap();
            CreateMap<RespostaEntrada, Resposta>().ReverseMap();
        }
    }
}
