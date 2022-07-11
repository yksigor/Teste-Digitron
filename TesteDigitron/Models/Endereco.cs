namespace TesteDigitron.Models
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public long CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int IdPessoa { get; set; }
    }
}
