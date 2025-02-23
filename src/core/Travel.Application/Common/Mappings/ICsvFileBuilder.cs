using Travel.Application.TourLists.Queries.ExportTours;

namespace Travel.Application.Common.Mappings
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTourPackagesFile(IEnumerable<TourPackageRecord> records);
    }
}