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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using WebMatrix.WebData;
using PropertyMarketplace.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PropertyMarketplace.Pages.Properties
{

    public class EditModel : DI_BasePageModel
    {

        private readonly PropertyMarketplace.Data.PropertyMarketplaceContext _context;

        public EditModel(PropertyMarketplace.Data.PropertyMarketplaceContext context, IAuthorizationService authorizationService,
        Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)

        {
            _context = context;
        }

        [BindProperty]
        public Models.Property Property { get; set; }

        public async Task<IActionResult> OnGetAsync(int? Id)
        {

            var currentUserId = UserManager.GetUserId(User);

            if (Id == null)
            {
                return NotFound();
            }
            Property = await _context.Property.Where(m => m.OwnerID == currentUserId)
                .FirstOrDefaultAsync(m => m.PropertyID == Id);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                      User, Property,
                                                      BaseModelOperations.Create);
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync()
        {
            

            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Property).State = EntityState.Modified;
           
            try
            {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(Property.PropertyID))
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
            private bool PropertyExists(int id)
            {
                return _context.Property.Any(e => e.PropertyID == id);
            }
        }
    }

