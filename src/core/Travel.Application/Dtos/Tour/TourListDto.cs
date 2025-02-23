using Travel.Application.Common.Mappings;
using Travel.Domain.Entities;

namespace Travel.Application.Dtos.Tour
{
    public class TourListDto : IMapFrom<TourList>
    {
        public int Id {get; set;}
        public string? City {get; set;}
        public string? About {get; set;}
        public IList<TourPackageDto> Items {get; set;} = [];
    }
}