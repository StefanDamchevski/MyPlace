using System.ComponentModel.DataAnnotations;

namespace MyPlace.ViewModels
{
    public class InputLoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
