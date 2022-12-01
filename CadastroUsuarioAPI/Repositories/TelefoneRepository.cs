using AutoMapper;
using CadastroUsuarioAPI.Context;
using CadastroUsuarioAPI.DTO;
using CadastroUsuarioAPI.Models;
using CadastroUsuarioAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarioAPI.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {

        private readonly MySQLContext _mySQLContext;
        private readonly IMapper _mapper;

        public TelefoneRepository(MySQLContext context, IMapper mapper)
        {
            _mySQLContext = context;
            _mapper = mapper;
        }

        public async Task<TelefoneDTO> CreateTelefone(TelefoneDTO telefoneDTO)
        {
            var telefone = _mapper.Map<Telefone>(telefoneDTO);
            await _mySQLContext.Telefones.AddAsync(telefone);
            await _mySQLContext.SaveChangesAsync();
            return _mapper.Map<TelefoneDTO>(telefone);
        }

        public async Task<bool> DeleteTelefone(int telefoneId)
        {
            try
            {
                var telefone = await _mySQLContext.Telefones.FirstOrDefaultAsync(p => p.Id == telefoneId);

                if (telefone == null)
                    return false;
                
                _mySQLContext.Telefones.Remove(telefone);
                await _mySQLContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<TelefoneDTO>> GetTelefone(int usuarioId)
        {
            var telefones = await _mySQLContext
                                    .Telefones
                                    .Where(telefone => telefone.UsuarioId == usuarioId)
                                    .ToListAsync();

            return _mapper.Map<List<TelefoneDTO>>(telefones);
        }

        public async Task<TelefoneDTO> UpdateTelefone(TelefoneDTO telefoneDTO)
        {
            var telefone = _mapper.Map<Telefone>(telefoneDTO);
            _mySQLContext.Telefones.Update(telefone);
            await _mySQLContext.SaveChangesAsync();
            return _mapper.Map<TelefoneDTO>(telefone);
        }
    }
}
