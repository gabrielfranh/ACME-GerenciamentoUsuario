using CadastroUsuarioAPI.DTO;

namespace CadastroEnderecoAPI.Repositories.Interface
{
    public interface IEnderecoRepository
    {
        public Task<IEnumerable<EnderecoDTO>> GetEndereco(int enderecoId);

        public Task<EnderecoDTO> CreateEndereco(EnderecoDTO enderecoDTO);

        public Task<EnderecoDTO> UpdateEndereco(EnderecoDTO enderecoDTO);

        public Task<bool> DeleteEndereco(int enderecoID);
    }
}
