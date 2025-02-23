using Microsoft.EntityFrameworkCore;
using Travel.Domain.Entities;

namespace Travel.Application.Common.interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TourList> TourLists { get; set; }
        DbSet<TourPackage> TourPackages { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}