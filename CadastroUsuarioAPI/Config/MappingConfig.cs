using AutoMapper;
using CadastroUsuarioAPI.DTO;
using CadastroUsuarioAPI.DTO.Usuario;
using CadastroUsuarioAPI.Models;

namespace AgendamentoAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UsuarioDTO, Usuario>().ReverseMap();
                config.CreateMap<CriaUsuarioDTO, Usuario>().ReverseMap();
                config.CreateMap<AtualizaUsuarioDTO, Usuario>().ReverseMap();
                config.CreateMap<EnderecoDTO, Endereco>().ReverseMap();
                config.CreateMap<TelefoneDTO, Telefone>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}