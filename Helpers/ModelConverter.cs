using MyPlace.Models;
using MyPlace.ViewModels;

namespace MyPlace.Helpers
{
    public static class ModelConverter
    {
        public static ImageViewModel ToImageViewModel(this Image image)
        {
            return new ImageViewModel
            {
                Id = image.Id,
                IsPrivate = image.IsPrivate,
                DateCreated = image.DateCreated,
                ImageUrl = image.ImageUrl,
                CreatedBy = image.UserId,
            };
        }

        public static CreateImageViewModel ToCreateImageViewModel(this Image image)
        {
            return new CreateImageViewModel
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
                IsPrivate = image.IsPrivate,
            };
        }
    }
}
