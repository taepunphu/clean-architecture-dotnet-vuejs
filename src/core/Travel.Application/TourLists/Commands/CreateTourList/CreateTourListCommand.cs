using MediatR;
using Travel.Application.Common.interfaces;
using Travel.Domain.Entities;

namespace Travel.Application.TourLists.Commands.CreateTourList
{
    public class CreateTourListCommand : IRequest<int>
    {
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
    }

    public class CreateTourListCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateTourListCommand, int>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<int> Handle(CreateTourListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TourList
            {
                City = request.City,
                Country = request.Country,
                About = request.About
            };

            _context.TourLists.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}