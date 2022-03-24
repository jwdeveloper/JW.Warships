using Microsoft.AspNetCore.Mvc;
using Warships.common.Interfaces.Services;
using Warships.game.Models.Player;

namespace Warships.Controllers;


[ApiController]
[Route("[controller]")]
public class PlayerController: ControllerBase
{
    private readonly ILogger<PlayerController> _logger;
    private readonly IPlayerService _playerService;

    public PlayerController(ILogger<PlayerController> logger, IPlayerService playerService)
    {
        _logger = logger;
        _playerService = playerService;
    }

    [HttpGet]
    public IEnumerable<IPlayer> Get()
    {
        return _playerService.GetPlayers();
    }
}