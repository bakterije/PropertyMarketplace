using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PropertyMarketplace.Models;
using PropertyMarketplace.Pages.Properties;

namespace PropertyMarketplace.Pages
{
    public class YourListingsModel : DI_BasePageModel
    {

        public YourListingsModel(PropertyMarketplace.Data.PropertyMarketplaceContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }



        public async Task OnGetAsync()
        {

           
            var currentUser = UserManager.GetUserId(User);
            AdsList = await Context.AdsBasicInfo.Include(a => a.Category)
                .Where(a => a.OwnerID == currentUser )
                .ToListAsync();
            Properties = await Context.Property.Include(x => x.AdsBasicInfo)
                .Where(p => p.OwnerID == currentUser)
                .ToListAsync();
            AutoMotos = await Context.AutoMoto.Include(x => x.AutoMotoModels.Manufacturers)
            .Where(x => x.OwnerID == currentUser).
                ToListAsync();
        }
    }
}
