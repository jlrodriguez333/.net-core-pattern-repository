using HCDirectory.Repository.Models;
using System;
using System.Linq;

namespace HCDirectory.Repository.Infrastructure
{
    public static class HCDirectoryInitializer
    {
        public static void Initialize(ApplicationDbContext context, HcIdentityDbContext contextoIdent)
        {
            context.Database.EnsureCreated();

            contextoIdent.Database.EnsureCreated();

            var registro = new HcIdentityRole()
            {               
                ConcurrencyStamp = String.Empty,
                Description = "Ejemplo",
                Name = "Ejemplo",
                NormalizedName = "Eje"               
            };
            contextoIdent.HcIdentityRoles.Add(registro);
            contextoIdent.SaveChanges();

            // Look for any students.
            if (context.Specialtys.Any())
            {
                return;   // DB has been seeded
            }

            var specialtys = new Specialty[]
            {
                new Specialty {SpecialtyId=1,SpecialtyName="Odontologia" },
                new Specialty {SpecialtyId=2,SpecialtyName="Pediatra" },
                new Specialty {SpecialtyId=3,SpecialtyName="Ginecologo" },
                new Specialty {SpecialtyId=4,SpecialtyName="Neurologo" },
                new Specialty {SpecialtyId=5,SpecialtyName="Obstetra" },
            };

            foreach (var specialty in specialtys)
            {
                context.Specialtys.Add(specialty);
            }
            context.SaveChanges();
          
        }
    }
}
