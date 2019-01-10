
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HCDirectory.Repository.Models
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }

        [Required]
        public string SpecialtyName { get; set; }

        //[Required]
        //public ICollection<Doctor> Doctor { get; set; }
    }
}
