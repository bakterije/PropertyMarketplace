using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PropertyMarketplace.Data;
using PropertyMarketplace.Models;
using PropertyMarketplace.Pages.Properties;

namespace PropertyMarketplace.Pages
{
    public class RealEstatePartial1Model : PageModel
    {
        private readonly PropertyMarketplaceContext _context;
        public RealEstatePartial1Model()
        : base()

        {

            
        }

        public IActionResult OnGet()
        {
        ViewData["AdID"] = new SelectList(_context.AdsBasicInfo, "AdID", "AdID");
            return Page();
        }

        [BindProperty]
        public Property Property { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            
            _context.Property.Add(Property);
            await _context.SaveChangesAsync();

            return null ;
        }
    }
}
