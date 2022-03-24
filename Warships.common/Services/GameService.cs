using Warships.common.Interfaces.Services;
using Warships.common.Proxy;
using Warships.game.Enums;
using Warships.game.Models.Player;

namespace Warships.common.Services;

public class GameService : IGameService
{
    private IList<IGame> _games = new List<IGame>();

    public IGame? FindByPlayer(IPlayer player)
    {
        return _games
            .FirstOrDefault(c => c.PlayerOne == player || c.PlayerTwo == player);
    }

    public IList<IGame> FindByStatus(GameStatus status)
    {
        return _games.Where(c => c.Status == status).ToList();
    }
    
    public void JoinToGame(IPlayer player, IGame game)
    {
        if (game.Status != GameStatus.Pending)
        {
            return;
        }

        if (game.PlayerOne is null)
        {
            return;
        }
        game.PlayerTwo = player;
        game.Status = GameStatus.Began;
    }
    
    public IGame CreateGame(IPlayer player)
    {
        var game = new GameProxy();
        game.PlayerOne = player;
        game.Status = GameStatus.Pending;
        _games.Add(game);
        return game;
    }
    
}