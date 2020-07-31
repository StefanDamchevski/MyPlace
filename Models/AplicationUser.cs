using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MyPlace.Models
{
    public class AplicationUser : IdentityUser
    {
        public List<Image> Images { get; set; }
    }
}
