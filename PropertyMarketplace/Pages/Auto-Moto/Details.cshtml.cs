using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyMarketplace.Data;
using PropertyMarketplace.Models;

namespace PropertyMarketplace.Pages.Auto_Moto
{
    public class DetailsModel : PageModel
    {
        private readonly PropertyMarketplace.Data.PropertyMarketplaceContext _context;

        public DetailsModel(PropertyMarketplace.Data.PropertyMarketplaceContext context)
        {
            _context = context;
        }

        public AutoMoto AutoMoto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AutoMoto = await _context.AutoMoto
                .Include(a => a.AdsBasicInfo)
                .Include(a => a.CarModels)
                .Include(a => a.Category)
                .Include(a => a.Manufacturers).FirstOrDefaultAsync(m => m.AutoMotoID == id);

            if (AutoMoto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
