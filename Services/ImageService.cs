using MyPlace.Models;
using MyPlace.Repositories.Interfaces;
using MyPlace.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace MyPlace.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public void CreateImage(string imageUrl, bool isPrivate, string userId)
        {
            Image image = new Image();
            image.ImageUrl = imageUrl;
            image.IsPrivate = isPrivate;
            image.UserId = userId;
            image.DateCreated = DateTime.Now;

            imageRepository.Add(image);
        }

        public void Delete(int id)
        {
            imageRepository.Delete(id);
        }

        public List<Image> GetAll()
        {
            return imageRepository.GetAll();
        }

        public Image GetById(int imageId)
        {
            return imageRepository.GetById(imageId);
        }

        public void Update(string imageUrl, bool isPrivate, int id)
        {
            Image image = imageRepository.GetById(id);
            image.ImageUrl = imageUrl;
            image.IsPrivate = isPrivate;

            imageRepository.Update(image);
        }
    }
}
