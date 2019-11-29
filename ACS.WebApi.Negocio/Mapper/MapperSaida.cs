using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Saidas;
using AutoMapper;

namespace ACS.WebApi.Negocio
{
    public class MapperSaida : Profile
    {
        public MapperSaida()
        {
            CreateMap<Usuario, UsuarioSaida>().ReverseMap();
            CreateMap<Paciente, PacienteSaida>()
                .ForMember(destino => destino.NomeResponsavel,
                            origem => origem.MapFrom(a => a.UsuarioResponsavel != null ? a.UsuarioResponsavel.Nome : "")).ReverseMap();
            CreateMap<Endereco, EnderecoSaida>().ReverseMap();
            CreateMap<Medicao, MedicaoSaida>().ReverseMap();
            CreateMap<Pergunta, PerguntaSaida>().ReverseMap();
            CreateMap<PacienteDetalheSaida, PacienteDetalheSaida>().ReverseMap();
            CreateMap<Remedio, RemedioSaida>().ReverseMap();
            CreateMap<Resposta, RespostaSaida>().ReverseMap();
        }
    }
}
