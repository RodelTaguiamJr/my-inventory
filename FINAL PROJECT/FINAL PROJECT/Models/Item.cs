using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;


namespace FINAL_PROJECT.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; } 

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Code { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0.00, 100000.00, ErrorMessage = "Invalid Price Range")]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        public int Available { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Date Modified")]
        //Nullable<DateTime>
        public DateTime? DateModified { get; set; }

        [Required(ErrorMessage = "Required")]
        public virtual Business Business { get; set; }
        public string? CatBusiness { get; set; }
    }
}
