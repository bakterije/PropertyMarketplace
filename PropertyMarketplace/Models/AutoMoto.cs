using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyMarketplace.Models
{
    public enum TransmissionTypes
    {
        Automatic,
        Manual
    }
    public class AutoMoto : BaseModel 
    {
        [Key]
        public int AutoMotoID { get; set; }
        [Display(Name = "Year of manufacture")]
        public int YearOfManufacture { get; set; }
        public int Mileage { get; set; }
        [ForeignKey("Manufacturers")]
        
        public int ManufacturerID { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
        [ForeignKey("AutoMotoModels")]
        public int ModelID { get; set; }

        public virtual AutoMotoModels  AutoMotoModels { get; set; }
     
        [Display(Name ="Transmission Type")]
        public TransmissionTypes TransmissionType { get; set; }
        
    }

   
}