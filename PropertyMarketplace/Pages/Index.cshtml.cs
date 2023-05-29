using System;
using WebMatrix.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PropertyMarketplace.Pages.Properties;
using PropertyMarketplace.Services;
using System.Collections.Generic;
using PropertyMarketplace.Models;

namespace PropertyMarketplace.Pages
{
    [AllowAnonymous]

    public class IndexModel : DI_BasePageModel
        {


    
        public IndexModel(PropertyMarketplace.Data.PropertyMarketplaceContext context, 
                IAuthorizationService authorizationService, ICategoryService categoryService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }



        public async Task OnGetAsync()
        {
            var cars = from p in Context.AutoMoto.Include(a => a.AdsBasicInfo)
                .Include(a => a.AutoMotoModels)
                .Include(a => a.Manufacturers) select p;
            var categories = from p in Context.Category select p;
            var properties = from p in Context.Property select p;
            var ads = from p in Context.AdsBasicInfo select p;

        


            if (!String.IsNullOrEmpty(SearchString))
            {
                cars = cars.Where(s => s.AdsBasicInfo.Location.Contains(SearchString) || s.AdsBasicInfo.Description.Contains(SearchString) || s.AutoMotoModels.ModelName.Contains(SearchString));
                properties = properties.Where(s => s.AdsBasicInfo.Location.Contains(SearchString) || s.AdsBasicInfo.Description.Contains(SearchString));

            }



            // Sortiranje po kategorijama  Listings = await listings.Where(s => s.categoryId ==8).ToListAsync();
            AutoMotos = await cars.OrderByDescending(x => x.AutoMotoID).Take(3).ToListAsync();
            //Properties = await properties.OrderByDescending(x => x.PropertyID).Take(3).ToListAsync();
            Properties = await properties.ToListAsync();
            Categories = await categories.ToListAsync();
            AdsList = await ads.ToListAsync();


           
}
     

    }
}
