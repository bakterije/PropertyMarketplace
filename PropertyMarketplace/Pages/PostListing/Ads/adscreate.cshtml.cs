using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PropertyMarketplace.Data;
using PropertyMarketplace.Models;
using Newtonsoft.Json;

namespace PropertyMarketplace.Pages.PostListing.Ads
{
    public class adscreateModel : PageModel
    {
        private readonly PropertyMarketplace.Data.PropertyMarketplaceContext _context;

        public adscreateModel(PropertyMarketplace.Data.PropertyMarketplaceContext context)
        {
            _context = context;
        }
   
        public IActionResult OnGet()
        {
        ViewData["categoryId"] = new SelectList(_context.Category, "categoryId", "categoryId");
            return Page();
        }
        public JsonResult ReturnJsonSubCategories(int categoryId)
        {
            var jsonData = _context.Category.Where(x => x.ParentId == categoryId).ToList();
            return new JsonResult(jsonData);
        }

        [BindProperty]
        public Models.AdsBasicInfo Ads { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AdsBasicInfo.Add(Ads);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
