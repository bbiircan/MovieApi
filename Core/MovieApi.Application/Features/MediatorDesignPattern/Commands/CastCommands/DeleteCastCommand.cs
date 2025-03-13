using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    public class DeleteCastCommand : IRequest
    {
        public int CastId { get; set; }

        public DeleteCastCommand(int castId)
        {
            CastId = castId;
        }
    }
}
