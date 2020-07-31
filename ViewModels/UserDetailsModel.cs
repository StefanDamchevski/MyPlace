using System.Collections.Generic;

namespace MyPlace.ViewModels
{
    public class UserDetailsModel
    {
        public string UserId { get; set; }
        public List<ImageViewModel> Images { get; set; }
    }
}
