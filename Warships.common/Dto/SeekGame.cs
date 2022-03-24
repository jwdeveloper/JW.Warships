using MediatR;
using Warships.game.Models.Player;

namespace Warships.common.Dto;

public class SeekGame
{
    public class Request : IRequest<Response>
    {
        public IPlayer Player{ get; set; }
    }

    public class Response
    {
        public bool Status{ get; set; }
        public string Message { get; set; }
    }
}