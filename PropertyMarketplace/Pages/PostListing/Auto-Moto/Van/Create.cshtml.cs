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

namespace PropertyMarketplace.Pages.PostListing.Auto_Moto.Van
{
    public class CreateModel : DI_BasePageModel
    {

        public IAutoMotoService _autoMotoService;
        public CreateModel(PropertyMarketplace.Data.PropertyMarketplaceContext context, IAutoMotoService autoMotoService,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)

        {
            _autoMotoService = autoMotoService;
        }

        [BindProperty(SupportsGet = true)]
        public int ManufacturerId { get; set; }
        [BindProperty]
        public int ModelId { get; set; }




        public void OnGet()
        {

            ViewData["ManufacturerID"] = new SelectList(from p in Context.Manufacturers.Where(x => x.CategoryId == 8) select p, "ManufacturerID", "ManufacturerName");

            ViewData["ModelID"] = new SelectList(from p in Context.CarModels.Where(x => x.ManufacturerID == ManufacturerId) select p, "ModelID", "ModelName");

        }




        public JsonResult OnGetVanModels()
        {

            return new JsonResult(_autoMotoService.GetVanModels(ManufacturerId));
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
            AutoMoto.CategoryId = 7;
            AutoMoto.AdsBasicInfo.CategoryId = AutoMoto.CategoryId;
            Context.AutoMoto.Add(AutoMoto);
            await Context.SaveChangesAsync();

            return RedirectToPage("/Auto-Moto/Cars/Index");
        }
    }
}