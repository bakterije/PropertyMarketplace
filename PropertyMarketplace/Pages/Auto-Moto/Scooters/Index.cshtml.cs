using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyMarketplace.Data;
using PropertyMarketplace.Models;

namespace PropertyMarketplace.Pages.Auto_Moto.Scooters
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
            AutoMoto = await _context.AutoMoto
                .Include(a => a.AdsBasicInfo)
                .Include(a => a.AutoMotoModels)
                .Include(a => a.Category)
                .Include(a => a.Manufacturers).ToListAsync();
        }
    }
}
