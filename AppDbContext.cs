using Microsoft.EntityFrameworkCore;
using WebParkingApp.Models;

namespace WebParkingApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<ParkingSpaceModel> ParkingSpaces { get; set; }

        public DbSet<ReservationModel> Reservations { get; set; }


    }
}
