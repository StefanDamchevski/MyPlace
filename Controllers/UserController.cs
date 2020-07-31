using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPlace.Helpers;
using MyPlace.Models;
using MyPlace.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AplicationUser> userManager;

        public UserController(UserManager<AplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public  IActionResult Register()
        {
            InputRegisterModel model = new InputRegisterModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(InputRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                bool exists = userManager.Users.Where(x => x.UserName.Equals(model.UserName)).Any();

                if (!exists)
                {
                    AplicationUser user = new AplicationUser();
                    user.Email = model.Email;
                    user.UserName = model.UserName;
         
                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login", "Auth");
                    }
                }
            }
            return View(model);
        }

        public IActionResult Details(string userId)
        {
            AplicationUser user = userManager.Users.Include(x => x.Images).FirstOrDefault(x => x.Id.Equals(userId));

            UserDetailsModel model = new UserDetailsModel();
            model.UserId = userId;
            model.Images = user.Images?.Select(x => x.ToImageViewModel()).ToList();
            return View(model);
        }

        public IActionResult AccountOverview(string userId)
        {
            AplicationUser user = userManager.Users.Include(x => x.Images).FirstOrDefault(x => x.Id.Equals(userId));
            UserDetailsModel model = new UserDetailsModel();
            model.UserId = user.Email;
            model.Images = user.Images.Select(x => x.ToImageViewModel()).ToList();
            return View(model);
        }
    }
}
