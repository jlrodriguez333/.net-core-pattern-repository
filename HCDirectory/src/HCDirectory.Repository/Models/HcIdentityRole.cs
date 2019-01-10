using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HCDirectory.Repository.Models
{
    public class HcIdentityRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
