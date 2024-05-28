using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BookStore.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        // Navigation property for the books owned by the user
        public ICollection<Book> Books { get; set; }

        // Property to store password reset token
        public string PasswordResetToken { get; set; }
    }
}
