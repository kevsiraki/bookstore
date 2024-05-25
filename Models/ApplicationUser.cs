using Microsoft.AspNetCore.Identity;

namespace BookStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Other properties
        
        public string PasswordResetToken { get; set; }
    }
}
