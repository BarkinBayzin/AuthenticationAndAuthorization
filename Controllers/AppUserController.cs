using AuthenticationAndAuthorization.Models.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAndAuthorization.Controllers
{
    [Authorize(Roles ="manager")]
    public class AppUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index() => View(_userManager.Users);
    }
}
