using Microsoft.AspNetCore.Identity;

namespace DailyQuotes.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
