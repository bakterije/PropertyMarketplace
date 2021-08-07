using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyMarketplace.Models
{
    public class Manufacturers
    {
        [Key]
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        [ForeignKey("Category")]
       public int CategoryId { get; set; }
        public Category Category { get; set; }

       
    }
}
