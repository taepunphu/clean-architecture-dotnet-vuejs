using MediatR;
using Microsoft.EntityFrameworkCore;
using Travel.Application.Common.Exceptions;
using Travel.Application.Common.interfaces;
using Travel.Domain.Entities;

namespace Travel.Application.TourLists.Commands.DeleteTourList
{
    public class DeleteTourListCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTourListCommandHandler(IApplicationDbContext _context) : IRequestHandler<DeleteTourListCommand>
    {
        public async Task<Unit> Handle(DeleteTourListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TourLists
              .Where(l => l.Id == request.Id)
              .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TourList), request.Id);
            }

            _context.TourLists.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}