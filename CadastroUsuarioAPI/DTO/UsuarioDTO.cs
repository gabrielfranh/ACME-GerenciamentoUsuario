namespace CadastroUsuarioAPI.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Documento { get; set; }
        public byte[]? SenhaHash { get; set; }
        public string Senha { get; set; }
    }
}
