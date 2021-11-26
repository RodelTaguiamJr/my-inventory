using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL_PROJECT.Models
{
    public class Business
    {

        [Key]
        public string BusId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]

        public Category Type { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.MultilineText)]
        public string SocialMedia { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required")]
        public virtual ApplicationUser BusinessOwnerID { get; set; }
        [MaxLength(450)]
        public string BOID { get; set; }

        public enum Category
        {
            MedicalSupplies = 1,
            Food = 2
        }
    }
}
