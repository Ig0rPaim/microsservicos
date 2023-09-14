using System.ComponentModel.DataAnnotations;

namespace LoginAPI.ValuesObjects
{
    public class UserVO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
