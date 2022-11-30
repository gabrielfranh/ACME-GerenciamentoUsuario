namespace CadastroUsuarioAPI.DTO
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
    }
}
