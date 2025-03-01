using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class DeleteCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public DeleteCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(DeleteCategoryCommand command)
        {
            var value = await _context.Categories.FindAsync(command.CategoryId);
            _context.Categories.Remove(value);
            await _context.SaveChangesAsync();
        } 
    }
}
