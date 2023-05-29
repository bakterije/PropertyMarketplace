using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PropertyMarketplace.Data;
using PropertyMarketplace.Models;
using PropertyMarketplace.Services;

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


        [BindProperty]
        public AutoMoto AutoMoto { get; set; }
        
        public ActionResult OnPostAuto()
        {
            _context.AutoMoto.Add(AutoMoto);
            _context.SaveChangesAsync();
            return null;

        }
        public ActionResult Upload ()
        {
            _context.AutoMoto.Add(AutoMoto);
             _context.SaveChangesAsync();
            return null;
        }
        public async Task<IActionResult> OnPost()

        {

            _context.AutoMoto.Add(AutoMoto);
            await _context.SaveChangesAsync();


            return null;
        }
    }
}
