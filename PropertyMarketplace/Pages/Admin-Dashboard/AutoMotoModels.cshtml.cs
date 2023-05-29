using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PropertyMarketplace.Data;
using PropertyMarketplace.Models;

namespace PropertyMarketplace.Pages.Admin_Dashboard
{
    public class AutoMotoModelsModel : PageModel
    {
        private readonly PropertyMarketplace.Data.PropertyMarketplaceContext _context;

        public AutoMotoModelsModel(PropertyMarketplace.Data.PropertyMarketplaceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SubCategoryID"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ManufacturerID", "ManufacturerName");
            return Page();
        }

        [BindProperty]
        public AutoMotoModels AutoMotoModels { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AutoMotoModels.Add(AutoMotoModels);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
