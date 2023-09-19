using Flunt.Notifications;
using Flunt.Validations;
using LoginAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LoginAPI.ValuesObjects
{
    public class UserVO : Notifiable<Notification>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public UserVO(int id, string nome, string password, string email, string phone)
        {
            var contract = new Contract<UserVO>() //Flunt
                .Requires()
                .IsNotNull(id, "Id", "Campo Id vazio")
                .IsNotNullOrEmpty(nome, "Nome", "Campo nome vazio")
                .IsNotNullOrEmpty(password, "Password", "Campo senha vazio")
                .IsNotNullOrEmpty(phone, "Phone", "Campo telefone vazio")
                .IsEmailOrEmpty(email, "Email", "Campo email vazio ou invalido");
            AddNotifications(contract);

            Id = id;
            Nome = nome;
            Password = password;
            Email = email;
            Phone = phone;
        }
    }
}
