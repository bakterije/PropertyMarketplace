using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyMarketplace.Models
{
    public class CarModels
    {
        [Key]
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        [ForeignKey("Manufacturers")]
        public int ManufacturerID { get; set; } 
        public virtual Manufacturers Manufacturers { get; set; }
        
    }

        

    
}
