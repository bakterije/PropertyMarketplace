using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMarketplace.Models
{
    
    public enum Condition
    {
        [Display(Name = "Brand New")]
        BrandNew,
        Used
    }

    public class AdsBasicInfo
    {
        [Key]
        public int AdID { get; set; }
        public string Title { get; set; }
        public string OwnerID { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ListingCreated { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public Condition Condition { get; set; }


    }
}
