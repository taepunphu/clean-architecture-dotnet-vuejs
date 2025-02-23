using MediatR;
using Travel.Application.Common.Exceptions;
using Travel.Application.Common.interfaces;
using Travel.Domain.Entities;

namespace Travel.Application.TourLists.Commands.UpdateTourList
{
    public class UpdateTourListCommand : IRequest
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
    }

    public class UpdateTourListCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateTourListCommand>
    {
        private readonly IApplicationDbContext _context = context;
        public async Task<Unit> Handle(UpdateTourListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TourLists.FindAsync(new object?[] { request.Id, cancellationToken }, cancellationToken: cancellationToken) ?? throw new NotFoundException(nameof(TourList), request.Id);
            entity.City = request.City;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}