using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class DeleteMovieCommandHandler
    {
        private readonly MovieContext _context;

        public DeleteMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(DeleteMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId);
            _context.Movies.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
