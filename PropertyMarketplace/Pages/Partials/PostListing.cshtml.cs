using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace PropertyMarketplace.Pages.Partials
{
    public class PostListingModel : DI_BasePageModel
    {

        readonly IAutoMotoService _autoMotoService;
        readonly ICategoryService _categoryService;

        public PostListingModel(PropertyMarketplace.Data.PropertyMarketplaceContext context, ICategoryService categoryService, IAutoMotoService autoMotoService,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)

        {
            _categoryService = categoryService;
            _autoMotoService = autoMotoService;
        }
        [BindProperty(SupportsGet =true)]
        [Display(Name = "Category")]
        public int categoryId { get; set; }
        [BindProperty]
        [Display(Name = "Sub Category")]
        public int SubCategoriesId { get; set; }
        public int ManufacturerId { get; set; }

        public IActionResult OnGet()
        {
        ViewData["categoryId"] = new SelectList(Context.Category.Where(x => x.ParentId == null), "CategoryId", "CategoryName");
            //ViewData["SubcategoriesId"] = new SelectList(_context.Category.Where(x => x.ParentId == categoryId), "CategoryId", "CategoryName");
            return Page();
        }
        /* public ActionResult AddPartial()
         {
             return Partial("AutoMotoPartial");
         }*/


        public IActionResult OnGetAddPartialToView(int categoryId)
        {
            

            if (categoryId == 2)
            {
                return Partial("AutoMotoPartial");

                //return Partial("AutoMotoPartial");

            }
            else if (categoryId == 1)
            {
            
                return Partial("RealEstatePartial1");
            }
            else
            {
               return null ;
            }

        }

        public JsonResult OnGetSubCategories()
        {

                    return new JsonResult(_categoryService.GetSubCategories(categoryId));
        }
        public JsonResult OnGetManufacturers()
        {

            return new JsonResult(_autoMotoService.GetManufacturers(SubCategoriesId));
        }

        public JsonResult OnGetCarModels()
        {

            return new JsonResult(_autoMotoService.GetCarModels(ManufacturerId));
        }
        [BindProperty]
        public AdsBasicInfo AdsBasicInfo { get; set; }
       
       

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            AdsBasicInfo.OwnerID = UserManager.GetUserId(User);
            AdsBasicInfo.CategoryId = SubCategoriesId;
            AdsBasicInfo.ListingCreated = DateTime.Now;


            

                Context.AdsBasicInfo.Add(AdsBasicInfo);
            
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
