using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyMarketplace.Data;
using Microsoft.AspNetCore.Identity;

namespace PropertyMarketplace.Pages.Properties
{
    [AllowAnonymous]
    public class DetailsModel : DI_BasePageModel
    {
       
        public DetailsModel( PropertyMarketplaceContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public Models.Property Property { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ads = from p in Context.AdsBasicInfo select p;
            Property = await Context.Property.FirstOrDefaultAsync(m => m.PropertyID == id);
            AdsList = await ads.ToListAsync();
            if (Property == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
