using Flunt.Notifications;

namespace LoginAPI.ValuesObjects
{
    public class UserVOOut
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public UserVOOut(string nome, string email, string phone)
        {
            Nome = nome;
            Email = email;
            Phone = phone;
        }

    }
}
