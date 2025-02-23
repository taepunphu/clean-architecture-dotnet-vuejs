using MediatR;
using Travel.Application.Common.Exceptions;
using Travel.Application.Common.interfaces;
using Travel.Domain.Entities;

namespace Travel.Application.TourPackages.Commands.UpdateTourPackage
{
    public class UpdateTourPackageCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateTourPackageCommandHandler(IApplicationDbContext _context) : IRequestHandler<UpdateTourPackageCommand>
    {
        public async Task<Unit> Handle(UpdateTourPackageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TourPackages.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken)
            ??  throw new NotFoundException(nameof(TourPackage), request.Id);
            
            entity.Name = request.Name;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}