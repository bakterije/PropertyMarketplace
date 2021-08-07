using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMarketplace.Models
{
    public class Category
    {
        public int CategoryId { get; set; } 
        public int? ParentId { get; set; }
        public string CategoryName { get; set; }
        public virtual Category Parent { get; set; }  
        public string ParentName { get; set; }
        public virtual ICollection<Category> Children { get; set; }
        
        
        


        
        
    }

}
