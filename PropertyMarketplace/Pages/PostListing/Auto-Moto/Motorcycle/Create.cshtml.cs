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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PropertyMarketplace.Pages.PostListing.Auto_Moto.Motorcycle
{ 
    public class CreateModel : DI_BasePageModel
    {
        private readonly PropertyMarketplace.Data.PropertyMarketplaceContext _context;
        public IAutoMotoService _autoMotoService;

        public ICategoryService _categoryService;

        public CreateModel(PropertyMarketplace.Data.PropertyMarketplaceContext context,ICategoryService categoryService ,IAutoMotoService autoMotoService,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        
        {
            _context = context;
            _autoMotoService = autoMotoService;
            _categoryService = categoryService;
        }

        [BindProperty( SupportsGet = true)]
      public int ManufacturerId  { get; set; }
       [BindProperty]
        public int ModelId { get; set; }
        
     
        
     
        public void OnGet()
        {
            
            ViewData["ManufacturerID"] = new SelectList(from p in _context.Manufacturers.Where(x => x.CategoryId == 2) select p, "ManufacturerID", "ManufacturerName");
            
         ViewData["ModelID"] = new SelectList(from p in _context.CarModels.Where(x => x.ManufacturerID == ManufacturerId) select p, "ModelID", "ModelName");
           
          }



        
        public JsonResult OnGetMotorcycleModels()
        {

            return new JsonResult(_autoMotoService.GetMotorcycleModels(ManufacturerId));
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
            AutoMoto.CategoryId = 9;
            AutoMoto.AdsBasicInfo.CategoryId = AutoMoto.CategoryId;
            _context.AutoMoto.Add(AutoMoto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
