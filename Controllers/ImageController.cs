using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
using MyPlace.Helpers;
using MyPlace.Models;
using MyPlace.Services.Interfaces;
using MyPlace.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MyPlace.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService imageService;
        private readonly UserManager<AplicationUser> userManager;

        public ImageController(IImageService imageService, UserManager<AplicationUser> userManager)
        {
            this.imageService = imageService;
            this.userManager = userManager;
        }
        public IActionResult Overview()
        {

                List<ImageViewModel> models = imageService.GetAll().Select(x => x.ToImageViewModel()).ToList();
                foreach (var model in models)
                {
                    var userEmail = userManager.Users.FirstOrDefault(x => x.Id.Equals(model.CreatedBy)).Email;
                    model.CreatedBy = userEmail;
                }
                return View(models);
        }

        public IActionResult Create()
        {
            CreateImageViewModel model = new CreateImageViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateImageViewModel model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            imageService.CreateImage(model.ImageUrl, model.IsPrivate, userId);
            return RedirectToAction(nameof(Overview));
        }

        public IActionResult Edit(int imageId)
        {
            CreateImageViewModel model = imageService.GetById(imageId).ToCreateImageViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CreateImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                imageService.Update(model.ImageUrl, model.IsPrivate, model.Id);
                return RedirectToAction(nameof(Overview));
            }
            return View(model);
        }

        public IActionResult Delete(int imageId)
        {
            imageService.Delete(imageId);
            return RedirectToAction(nameof(Overview));
        }
    }
}