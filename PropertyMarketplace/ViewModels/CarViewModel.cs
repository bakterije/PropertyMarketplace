using PropertyMarketplace.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMarketplace.ViewModels
{
    public class CarViewModel
    {
    
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public virtual Category Category { get; set; }
        public Condition Condition { get; set; }
        [Key]
        public int AutoMotoID { get; set; }
        [Display(Name = "Year of manufacture")]
        public int YearOfManufacture { get; set; }
        public int Mileage { get; set; }
        public int ManufacturerID { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
        public int ModelID { get; set; }
        public virtual CarModels CarModels { get; set; }
        [Display(Name = "Transmission Type")]
        public TransmissionTypes TransmissionType { get; set; }

    }
}
