using System.ComponentModel.DataAnnotations;

namespace LoginAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a senha do Usuário")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Digite o Email do Usuário")]
        [EmailAddress(ErrorMessage = "O email não está em um formato válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o telefone do Usuário")]
        [Phone(ErrorMessage = "Formato de telefone invalido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(##) ####-####}")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Formato de telefone inválido, Digite o DDD e os outros nove digitos, todos juntos")]

        public string Phone { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }


    }
}
