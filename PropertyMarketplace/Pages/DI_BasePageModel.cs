using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PropertyMarketplace.Data;
using PropertyMarketplace.Models;
using PropertyMarketplace.Services;
using System.Collections.Generic;

namespace PropertyMarketplace.Pages.Properties
{
    public class DI_BasePageModel : PageModel
    {
        protected  PropertyMarketplaceContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<IdentityUser> UserManager { get; }


        public IList<Models.AdsBasicInfo> AdsList { get; set; }
        public IList<Property> Properties { get; set; }
        public IList<AutoMoto> AutoMotos { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<CarModels> Models { get; set; }
        public IList<Manufacturers> Manufacturers { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
       



        public DI_BasePageModel(
            PropertyMarketplaceContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager) : base()
        {
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;

    }


       
    }

}
