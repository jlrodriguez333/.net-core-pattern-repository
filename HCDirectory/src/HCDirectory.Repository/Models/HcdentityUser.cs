using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace HCDirectory.Repository.Models
{
    public class HcdentityUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
