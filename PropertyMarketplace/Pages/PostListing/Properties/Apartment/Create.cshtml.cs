using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration.UserSecrets;
using PropertyMarketplace.Authorization;
using PropertyMarketplace.Data;
using PropertyMarketplace.Models;
using PropertyMarketplace.Pages.Properties;

namespace PropertyMarketplace.Pages.PostListing.Properties.Apartment
{

    public class CreateModel : DI_BasePageModel
    {


        public CreateModel(PropertyMarketplaceContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }
        [BindProperty]
        public Property Property { get; set; }
      
        


        public IActionResult OnGet()
        {
            ViewData["CategoryName"] = new SelectList(Context.Category.Where(c => c.ParentId == 1), "categoryId", "CategoryName");
            return Page();
            
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Property.OwnerID = UserManager.GetUserId(User);
            Property.AdsBasicInfo.ListingCreated = DateTime.Now;
            Property.CategoryId = Property.AdsBasicInfo.CategoryId = 5;



            // requires using ContactManager.Authorization;
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, Property,
                                                        BaseModelOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }


        
           
          
            
            Context.Property.Add(Property);
           
          
            await Context.SaveChangesAsync();

            return RedirectToPage("/Properties/Apartments/Index");
        }
    }
}
