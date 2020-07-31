using MyPlace.Models;
using System.Collections.Generic;

namespace MyPlace.Services.Interfaces
{
    public interface IImageService
    {
        List<Image> GetAll();
        void CreateImage(string imageUrl, bool isPrivate, string userId);
        Image GetById(int imageId);
        void Update(string imageUrl, bool isPrivate, int id);
        void Delete(int id);
    }
}
