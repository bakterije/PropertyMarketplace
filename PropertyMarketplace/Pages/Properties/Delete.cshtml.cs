using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyMarketplace.Data;
using PropertyMarketplace.Models;
using PropertyMarketplace.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace PropertyMarketplace.Pages.Properties
{
    public class DeleteModel : DI_BasePageModel
    {
        private readonly PropertyMarketplace.Data.PropertyMarketplaceContext _context;

        public DeleteModel(PropertyMarketplace.Data.PropertyMarketplaceContext context, IAuthorizationService authorizationService,
        Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; }
        public AdsBasicInfo Ads { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var currentUserId = UserManager.GetUserId(User);
             if (id == null)
            {
                return NotFound();
            }

            Property = await _context.Property.Where(m => m.OwnerID == currentUserId)
                .Include(a => a.AdsBasicInfo)
                .FirstOrDefaultAsync(m => m.PropertyID == id);
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                       User, Property,
                                                       BaseModelOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            if (Property == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Property = await _context.Property.FindAsync(id);
            Property.OwnerID = UserManager.GetUserId(User);
            Ads = await _context.AdsBasicInfo.FindAsync(Property.AdID);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, Property,
                                                     BaseModelOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            if (Property != null)
            {
                _context.AdsBasicInfo.Remove(Ads);
                _context.Property.Remove(Property);
                
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
