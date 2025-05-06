using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class DeleteTagCommand : IRequest
    {
        public int TagId { get; set; }

        public DeleteTagCommand(int tagId)
        {
            TagId = tagId;
        }
    }
}
