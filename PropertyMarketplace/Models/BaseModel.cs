using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMarketplace.Models
{
    public class BaseModel
    {
        [ForeignKey("AdsBasicInfo")]
        public int AdID {get;set;}
        public virtual AdsBasicInfo AdsBasicInfo { get; set; }
        public string OwnerID { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }       
    }
}
