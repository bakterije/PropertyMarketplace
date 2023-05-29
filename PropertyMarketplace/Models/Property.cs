using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyMarketplace.Models
{
    public enum HouseTypes
    {
        Detached,
        [Display(Name = " Semi Detached")]
        SemiDetached,
        Terraced
    }
    public class Property: BaseModel
    {
      
        [Display(Name ="House Type")]
        public HouseTypes HouseType { get; set; }
        public int PropertyID { get; set; }
        [Display(Name = "Energy Rating")]
        [Required]
        public string EnergyRating { get; set; }
   
        [Display(Name ="Number of rooms")]
        [Range(1,10)]
        public int NumberOfRooms { get; set; }
        [Display(Name ="Overall floor area in m2")]
        public int FloorArea { get; set; }
     
      
        
        






    }
}
