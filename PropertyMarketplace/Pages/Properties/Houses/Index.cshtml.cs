using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PropertyMarketplace.Data;
using PropertyMarketplace.Models;

namespace PropertyMarketplace.Pages.Properties.Houses
{
    [AllowAnonymous]
    
    public class IndexModel : DI_BasePageModel
    {
        

        public IndexModel(
        PropertyMarketplaceContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }



        public async Task OnGetAsync()
        {
              var categories = from p in Context.Category select p;
            var properties = from c in Context.Property  select c;
            var ads = from p in Context.AdsBasicInfo select p;


            if (!String.IsNullOrEmpty(SearchString))
            {
                ads = ads.Where(s => s.Location.Contains(SearchString) || s.Description.Contains(SearchString));
                properties = properties.Where(s => s.AdsBasicInfo.Location.Contains(SearchString) || s.AdsBasicInfo.Description.Contains(SearchString));

            }
           
            Properties = await properties.ToListAsync(); 
            AdsList = await ads.ToListAsync();
            Categories = await categories.ToListAsync();


        }
    }
}

