using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyPlace.Models
{
    public class MyPlaceDbContext : IdentityDbContext<AplicationUser>
    {
        public MyPlaceDbContext(DbContextOptions<MyPlaceDbContext> options) : base(options) {}
        public DbSet<Image> Images { get; set; }
    }
}
