using MediatR;
using Microsoft.AspNetCore.SignalR;
using Warships.common.Dto;
using Warships.common.Interfaces.Services;
using Warships.game.Models.Player;

namespace Warships.Hubs;

public class LobbyHub : Hub
{
    private readonly IPlayerService _playerService;
    private readonly IMediator _mediator;
    private readonly ILogger _logger;

    public LobbyHub(IPlayerService playerService, IMediator mediator, ILogger logger)
    {
        _playerService = playerService;
        _mediator = mediator;
        _logger = logger;
    }

    public void SeekGame()
    {
        if (!ValidateConnection(out IPlayer player))
        {
            return;
        }

        var response = _mediator.Send(new SeekGame.Request
        {
            Player = player
        });
        player.Send(response);
    }

    public override Task OnConnectedAsync()
    {
        var dto = new PlayerDto.Create
        {
            Name = Context.UserIdentifier,
            ConnectionId = Context.ConnectionId,
            ClientProxy = Clients.Client(Context.ConnectionId)
        };
        
        var player = _playerService.AddPlayer(dto);
        _logger.LogDebug("User connected",player.Id);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _playerService.RemovePlayer(Context.ConnectionId);
        _logger.LogDebug("User disconnected");
        return base.OnDisconnectedAsync(exception);
    }

    private bool ValidateConnection(out IPlayer player)
    {
        player = _playerService.GetPlayer(Context.ConnectionId);
        _logger.LogDebug("User validated ",Context.ConnectionId);
        return player != null;
    }
}