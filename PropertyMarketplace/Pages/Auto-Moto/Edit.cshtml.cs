using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyMarketplace.Data;
using PropertyMarketplace.Models;

namespace PropertyMarketplace.Pages.Auto_Moto
{
    public class EditModel : PageModel
    {
        private readonly PropertyMarketplace.Data.PropertyMarketplaceContext _context;

        public EditModel(PropertyMarketplace.Data.PropertyMarketplaceContext context)
        {
            _context = context;
        }

        [BindProperty]
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
                .Include(a => a.Manufacturers).FirstOrDefaultAsync(m => m.AdID == id);

            if (AutoMoto == null)
            {
                return NotFound();
            }
           ViewData["AdID"] = new SelectList(_context.AdsBasicInfo, "AdID", "AdID");
           ViewData["ModelID"] = new SelectList(_context.CarModels, "ModelID", "ModelID");
           ViewData["categoryId"] = new SelectList(_context.Category, "categoryId", "categoryId");
           ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ManufacturerID", "ManufacturerID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AutoMoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoMotoExists(AutoMoto.AdID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AutoMotoExists(int id)
        {
            return _context.AutoMoto.Any(e => e.AdsBasicInfo.AdID == id);
        }
    }
}
