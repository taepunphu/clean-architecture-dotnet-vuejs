using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Travel.Application.Common.interfaces;
using Travel.Application.Dtos.Tour;

namespace Travel.Application.TourLists.Queries.GetTours
{
    public class GetToursQuery : IRequest<ToursVm>
    {

    }

    public class GetToursQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetToursQuery, ToursVm>
    {
        public readonly IApplicationDbContext _context = context;
        public readonly IMapper _mapper = mapper;

        public async Task<ToursVm> Handle(GetToursQuery request, CancellationToken cancellationToken)
        {
            return new ToursVm
            {
                Lists = await _context.TourLists.ProjectTo<TourListDto>(_mapper.ConfigurationProvider).OrderBy(t => t.City).ToListAsync(cancellationToken)
            };
        }
    }
}