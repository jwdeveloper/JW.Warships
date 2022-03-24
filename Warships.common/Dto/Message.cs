using MediatR;
using Warships.game.Models.Player;

namespace Warships.common.Dto;

public class Message
{
    public class Request : IRequest<Response>
    {
        public Guid PlayerId { get; set; }
    }

    public class Response
    {
        public string Message { get; set; }
        
        public Guid PlayerId { get; set; }
    }
}