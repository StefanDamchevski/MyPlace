using System;
using System.ComponentModel.DataAnnotations;

namespace MyPlace.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public bool IsPrivate { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public string UserId { get; set; }
        public AplicationUser User{ get; set; }
    }
}
