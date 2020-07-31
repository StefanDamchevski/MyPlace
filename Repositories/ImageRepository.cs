using MyPlace.Models;
using MyPlace.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyPlace.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly MyPlaceDbContext context;

        public ImageRepository(MyPlaceDbContext context)
        {
            this.context = context;
        }

        public void Add(Image image)
        {
            context.Images.Add(image);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Image image = GetById(id);

            context.Images.Remove(image);
            context.SaveChanges();
        }

        public List<Image> GetAll()
        {
            return context.Images.ToList();
        }

        public Image GetById(int imageId)
        {
            return context.Images.FirstOrDefault(x => x.Id.Equals(imageId));
        }

        public void Update(Image image)
        {
            context.Images.Update(image);
            context.SaveChanges();
        }
    }
}
