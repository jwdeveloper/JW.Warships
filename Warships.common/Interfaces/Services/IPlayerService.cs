using Microsoft.AspNetCore.SignalR;
using Warships.common.Dto;
using Warships.game.Models.Player;

namespace Warships.common.Interfaces.Services;

public interface IPlayerService
{
    public IList<IPlayer> GetPlayers();
    public IPlayer GetPlayer(string connectionId);

    public IPlayer? AddPlayer(PlayerDto.Create createPlayerDto);

    public void RemovePlayer(string connectionId);

}