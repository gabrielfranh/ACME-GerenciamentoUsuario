using AutoMapper;
using CadastroUsuarioAPI.DTO;
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
                config.CreateMap<EnderecoDTO, Endereco>().ReverseMap();
                config.CreateMap<TelefoneDTO, Telefone>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}