using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyMarketplace.Models;
using PropertyMarketplace.Pages.Properties;

namespace PropertyMarketplace.Pages.Auto_Moto.Cars
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
            AutoMoto = await Context.AutoMoto.Where(x=> x.CategoryId == 7   )
                .Include(a => a.AdsBasicInfo)
                .Include(a => a.AutoMotoModels)
                .Include(a => a.Category)
                .Include(a => a.Manufacturers).ToListAsync();
        }
    }
}
