using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPlace.Models;
using MyPlace.ViewModels;
using System.Threading.Tasks;

namespace MyPlace.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<AplicationUser> signInManager;
        private readonly UserManager<AplicationUser> userManager;

        public AuthController(SignInManager<AplicationUser> signInManager, UserManager<AplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        
        public IActionResult Login()
        {
            InputLoginModel model = new InputLoginModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(InputLoginModel model)
        {
            if (ModelState.IsValid)
            {
                AplicationUser user = await userManager.FindByEmailAsync(model.Email);

                if(user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Overview", "Image");
                    }
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Overview", "Image");
        }
    }
}
