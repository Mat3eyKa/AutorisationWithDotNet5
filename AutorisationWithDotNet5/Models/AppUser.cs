using Microsoft.AspNetCore.Identity;
namespace IdentityAutorisationWithDotNet5.Models
{
    // создаем свою реализацию AppUser
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
