using Microsoft.EntityFrameworkCore;
using Travel.Domain.Entities;

namespace Travel.Data.Contexts
{
    public class TravelDbContext(DbContextOptions<TravelDbContext> options) : DbContext(options)
    {
        public DbSet<TourList> TourLists { get; set; }
        public DbSet<TourPackage> TourPackages { get; set; }
    }
}