using MediatR;
using Travel.Application.Common.Exceptions;
using Travel.Application.Common.interfaces;
using Travel.Domain.Entities;

namespace Travel.Application.TourPackages.Commands.DeleteTourPackage
{
    public class DeleteTourPackageCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTourPackageCommandHandler(IApplicationDbContext _context) : IRequestHandler<DeleteTourPackageCommand>
    {
        public async Task<Unit> Handle(DeleteTourPackageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TourPackages.FindAsync(new object?[] { request.Id, cancellationToken }, cancellationToken: cancellationToken) 
            ?? throw new NotFoundException(nameof(TourPackage), request.Id);

            _context.TourPackages.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}