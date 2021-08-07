using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
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

namespace PropertyMarketplace.Pages.Partials
{
    public class AutoMotoPartial
    {
        protected PropertyMarketplaceContext _context { get; }
        protected IAuthorizationService _authorizationService { get; }
        protected Microsoft.AspNetCore.Identity.UserManager<IdentityUser> UserManager { get; }
        protected IAutoMotoService _autoMotoService { get; }

        public AutoMotoPartial(PropertyMarketplace.Data.PropertyMarketplaceContext context, IAutoMotoService autoMotoService,
        IAuthorizationService authorizationService,
        Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager)
        : base()

        {
            _context = context;
            _autoMotoService = autoMotoService;
            _authorizationService = authorizationService;

        }

        [BindProperty(SupportsGet = true)]
        public int ManufacturerId { get; set; }
        [BindProperty]
        public int ModelId { get; set; }


        public IActionResult OnGet()
        {
            return null;
        }


        public JsonResult OnGetCarModels()
        {

            return new JsonResult(_autoMotoService.GetCarModels(ManufacturerId));
        }


        [BindProperty]
        public AutoMoto AutoMoto { get; set; }

    }
}