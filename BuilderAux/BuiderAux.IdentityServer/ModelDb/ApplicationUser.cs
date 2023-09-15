using Microsoft.AspNetCore.Identity;

namespace BuiderAux.IdentityServer.ModelDb
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
