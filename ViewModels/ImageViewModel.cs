using System;

namespace MyPlace.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrivate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}