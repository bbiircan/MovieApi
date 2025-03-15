using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class DeleteCastCommandHandler : IRequestHandler<DeleteCastCommand>
    {
        private readonly MovieContext _context;
        public DeleteCastCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteCastCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.FindAsync(request.CastId);
            _context.Casts.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
