namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    public class DeleteMovieCommand
    {
        public DeleteMovieCommand(int movieId)
        {
            MovieId = movieId;
        }

        public int MovieId { get; set; }
    }
}
