using CadastroUsuarioAPI.DTO;

namespace CadastroUsuarioAPI.Repositories.Interface
{
    public interface ITelefoneRepository
    {
        public Task<IEnumerable<TelefoneDTO>> GetTelefone();

        public Task<TelefoneDTO> CreateTelefone(TelefoneDTO telefoneDTO);

        public Task<TelefoneDTO> UpdateTelefone(TelefoneDTO telefoneDTO);

        public Task<bool> DeleteTelefone(int telefoneId);
    }
}
