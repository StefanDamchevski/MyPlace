using MyPlace.Models;
using System.Collections.Generic;

namespace MyPlace.Repositories.Interfaces
{
    public interface IImageRepository
    {
        List<Image> GetAll();
        void Add(Image image);
        Image GetById(int imageId);
        void Update(Image image);
        void Delete(int id);
    }
}
