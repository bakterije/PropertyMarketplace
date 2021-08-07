using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertyMarketplace.Models;
namespace PropertyMarketplace.Data
{
    public class PropertyMarketplaceContext : IdentityDbContext
    {
        public PropertyMarketplaceContext (DbContextOptions<PropertyMarketplaceContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Property { get; set; }
   
        public DbSet<AutoMoto> AutoMoto { get; set; }
     
        public DbSet<Category> Category { get; set; }
        public DbSet<CarModels> CarModels { get; set; }
        public DbSet<Manufacturers> Manufacturers { get; set; }
        public DbSet<AdsBasicInfo> AdsBasicInfo { get; set; }
        
        
    
    }
}
