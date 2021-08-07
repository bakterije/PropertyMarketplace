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

namespace PropertyMarketplace.Pages.Properties
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
            var properties = from c in Context.Property select c;
            var ads = from p in Context.AdsBasicInfo select p;
            Properties = await properties.ToListAsync();
            AdsList = await ads.ToListAsync();
        }
    }
}

