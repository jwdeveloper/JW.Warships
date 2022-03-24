using Warships.game.Enums;
using Warships.game.Models.Player;

namespace Warships.common.Interfaces.Services;

public interface IGameService
{
    public IGame? FindByPlayer(IPlayer player);

    public IList<IGame> FindByStatus(GameStatus status);

    public void JoinToGame(IPlayer player, IGame game);

    public IGame CreateGame(IPlayer player);
}