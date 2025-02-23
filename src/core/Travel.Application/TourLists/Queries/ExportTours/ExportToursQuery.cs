using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Travel.Application.Common.interfaces;
using Travel.Application.Common.Mappings;

namespace Travel.Application.TourLists.Queries.ExportTours
{
    public class ExportToursQuery : IRequest<ExportToursVm>
    {
        public int ListId { get; set; }
    }

    public class ExportToursQueryHandler(IApplicationDbContext context, ICsvFileBuilder csvFileBuilder, IMapper mapper) : IRequestHandler<ExportToursQuery, ExportToursVm>
    {
        private readonly IApplicationDbContext _context = context;
        private readonly ICsvFileBuilder _fileBuilder = csvFileBuilder;
        private readonly IMapper _mapper = mapper;

        public async Task<ExportToursVm> Handle(ExportToursQuery request, CancellationToken cancellationToken)
        {
            var records = await _context.TourPackages
                .Where(t => t.ListId == request.ListId)
                .ProjectTo<TourPackageRecord>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new ExportToursVm
            {
                ContentType = "text/csv",
                FileName = "TourPackages.csv",
                Content = _fileBuilder.BuildTourPackagesFile(records)
            };

            return vm;
        }
    }
}