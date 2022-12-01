using AutoMapper;
using CadastroEnderecoAPI.Repositories.Interface;
using CadastroUsuarioAPI.Context;
using CadastroUsuarioAPI.DTO;
using CadastroUsuarioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarioAPI.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly MySQLContext _mySQLContext;
        private readonly IMapper _mapper;

        public EnderecoRepository(MySQLContext context, IMapper mapper)
        {
            _mySQLContext = context;
            _mapper = mapper;
        }

        public async Task<EnderecoDTO> CreateEndereco(EnderecoDTO enderecoDTO)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDTO);
            await _mySQLContext.Enderecos.AddAsync(endereco);
            await _mySQLContext.SaveChangesAsync();
            return _mapper.Map<EnderecoDTO>(endereco);
        }

        public async Task<bool> DeleteEndereco(int enderecoId)
        {
            try
            {
                var endereco = await _mySQLContext.Enderecos.Where(p => p.Id == enderecoId).FirstOrDefaultAsync();

                if (endereco == null)
                    return false;
                else
                {
                    _mySQLContext.Enderecos.Remove(endereco);
                    await _mySQLContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<EnderecoDTO>> GetEndereco(int usuarioId)
        {
            var enderecos = await _mySQLContext
                                    .Enderecos
                                    .Where(endereco => endereco.UsuarioId == usuarioId)
                                    .ToListAsync();

            return _mapper.Map<List<EnderecoDTO>>(enderecos);
        }

        public async Task<EnderecoDTO> UpdateEndereco(EnderecoDTO enderecoDTO)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDTO);
            _mySQLContext.Enderecos.Update(endereco);
            await _mySQLContext.SaveChangesAsync();
            return _mapper.Map<EnderecoDTO>(endereco);
        }
    }
}
