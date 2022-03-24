using Microsoft.AspNetCore.SignalR;
using Warships.common.Dto;
using Warships.common.Interfaces.Services;
using Warships.common.Proxy;
using Warships.game.Models.Player;

namespace Warships.common.Services;

public class PlayerService : IPlayerService
{
    private IDictionary<string, IPlayer> _players;

    public PlayerService()
    {
        _players = new Dictionary<string, IPlayer>();
    }

    public IList<IPlayer> GetPlayers()
    {
        return _players.Values.ToList();
    }

    public IPlayer GetPlayer(string connectionId)
    {
        IPlayer? player;
        if (_players.TryGetValue(connectionId, out player))
        {
            return player;
        }

        return player;
    }

    public IPlayer? AddPlayer(PlayerDto.Create createPlayerDto)
    {
        lock (_players)
        {
            if (!_players.TryGetValue(createPlayerDto.ConnectionId, out IPlayer player))
            {
                PlayerProxy? playerProxy = new PlayerProxy(createPlayerDto.ClientProxy);
                playerProxy.Name = createPlayerDto.Name;
                playerProxy.JoinDate = DateTimeOffset.Now;
                _players.Add(createPlayerDto.ConnectionId, playerProxy);
                return playerProxy;
            }
        }
        return null;
    }

    public void RemovePlayer(string connectionId)
    {
        lock (_players)
        {
            _players.Remove(connectionId);
        }
    }
}