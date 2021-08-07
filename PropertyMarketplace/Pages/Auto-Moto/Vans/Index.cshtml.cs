using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyMarketplace.Models;

namespace PropertyMarketplace.Pages.Auto_Moto.Vans
{
    public class IndexModel : PageModel
    {
        private readonly PropertyMarketplace.Data.PropertyMarketplaceContext _context;

        public IndexModel(PropertyMarketplace.Data.PropertyMarketplaceContext context)
        {
            _context = context;
        }

        public IList<AutoMoto> AutoMoto { get;set; }

        public async Task OnGetAsync()
        {
            AutoMoto = await _context.AutoMoto.Where(x=> x.CategoryId == 8   )
                .Include(a => a.AdsBasicInfo)
                .Include(a => a.CarModels)
                .Include(a => a.Category)
                .Include(a => a.Manufacturers).ToListAsync();
        }
    }
}
