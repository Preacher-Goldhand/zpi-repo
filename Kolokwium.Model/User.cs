using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Kolokwium.Model
{
    public class User : IdentityUser<int> 
    {
         public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}