using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyMarketplace.Models;
using PropertyMarketplace.Pages.Properties;

namespace PropertyMarketplace.Pages.Auto_Moto
{
    public class IndexModel : DI_BasePageModel
    {
       

        public IndexModel(PropertyMarketplace.Data.PropertyMarketplaceContext context,
                IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        
            
        
        {
           
        }

        public IList<AutoMoto> AutoMoto { get;set; }

        public async Task OnGetAsync()
        {
            var cars = from a in Context.AutoMoto
                .Include(a => a.AdsBasicInfo)
                .Include(a => a.AutoMotoModels)
                .Include(a => a.Category)
                .Include(a => a.Manufacturers) select a;

            if (!String.IsNullOrEmpty(SearchString))
            {
                cars = cars.Where(s => s.AdsBasicInfo.Location.Contains(SearchString) || s.AdsBasicInfo.Description.Contains(SearchString) || s.AutoMotoModels.ModelName.Contains(SearchString));

            }



            // Sortiranje po kategorijama  Listings = await listings.Where(s => s.categoryId ==8).ToListAsync();
            AutoMoto = await cars.ToListAsync();
        }
    }
}
