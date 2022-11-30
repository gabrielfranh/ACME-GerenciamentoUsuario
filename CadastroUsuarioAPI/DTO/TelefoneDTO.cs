namespace CadastroUsuarioAPI.DTO
{
    public class TelefoneDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Ddd { get; set; }
        public string NumeroTelefone { get; set; }
    }
}
