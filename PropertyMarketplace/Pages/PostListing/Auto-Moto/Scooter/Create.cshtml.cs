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
using PropertyMarketplace.Services;

namespace PropertyMarketplace.Pages.PostListing.Auto_Moto.Scooter
{
    public class CreateModel : DI_BasePageModel
    {
        private readonly PropertyMarketplaceContext _context;
        public IAutoMotoService _autoMotoService;
        public CreateModel(PropertyMarketplaceContext context, IAutoMotoService autoMotoService,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)

        {
            _autoMotoService = autoMotoService;
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int ManufacturerId { get; set; }
        [BindProperty]
        public int ModelId { get; set; }

        public IActionResult OnGet()
        {
   
    
    
        ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers.Where(x => x.CategoryId == 10), "ManufacturerID", "ManufacturerName");
            ViewData["ModelID"] = new SelectList(_context.CarModels.Where(x => x.ManufacturerID == ManufacturerId), "ModelID", "ModelName");
            return Page();
        }
        public JsonResult OnGetScooterModels()
        {

            return new JsonResult(_autoMotoService.GetScooterModels(ManufacturerId));
        }

        [BindProperty]
        public AutoMoto AutoMoto { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            AutoMoto.AdsBasicInfo.ListingCreated = DateTime.Now;
            AutoMoto.OwnerID = UserManager.GetUserId(User);
            AutoMoto.AdsBasicInfo.OwnerID = AutoMoto.OwnerID;
            AutoMoto.ManufacturerID = ManufacturerId;
            AutoMoto.ModelID = ModelId;
            AutoMoto.CategoryId = 10;
            AutoMoto.AdsBasicInfo.CategoryId = AutoMoto.CategoryId;
            _context.AutoMoto.Add(AutoMoto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
