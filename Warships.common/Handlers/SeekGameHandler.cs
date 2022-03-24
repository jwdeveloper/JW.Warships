using MediatR;
using Warships.common.Dto;
using Warships.common.Interfaces.Services;
using Warships.common.Services;
using Warships.game.Enums;

namespace Warships.common.Handlers;

public class SeekGameHandler : IRequestHandler<SeekGame.Request,SeekGame.Response>
{
    private readonly IGameService _gameService;
    
    public SeekGameHandler(IGameService gameService)
    {
        _gameService = gameService;
    }

    public async Task<SeekGame.Response> Handle(SeekGame.Request request, CancellationToken cancellationToken)
    {
        var game = _gameService.FindByPlayer(request.Player);
        if (game is not null)
        {
            return new SeekGame.Response
            {
                Message = "You are already in game",
                Status = false,
            };
        }

        var pendingGames = _gameService.FindByStatus(GameStatus.Pending);
        game = pendingGames.FirstOrDefault();
        if (game is null)
        {
            _gameService.CreateGame(request.Player);
            return new SeekGame.Response
            {
                Message = "You had created new game",
                Status = false,
            };
        }
        else
        {
            _gameService.JoinToGame(request.Player, game);
            return new SeekGame.Response
            {
                Message = "You had joined to game",
                Status = false,
            };
        }
    }
}