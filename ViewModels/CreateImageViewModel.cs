using System.ComponentModel.DataAnnotations;

namespace MyPlace.ViewModels
{
    public class CreateImageViewModel
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public bool IsPrivate { get; set; }
    }
}
