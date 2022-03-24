using Warships.game.Enums;
using Warships.game.Models.Player;

namespace Warships.common.Proxy;

public class GameProxy : IGame
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public IList<ITour> Tours { get; set; }
    public IPlayer PlayerOne { get; set; }
    public IPlayer PlayerTwo { get; set; }

    public GameStatus Status
    {
        get { return _status; }
        set
        {
            OnGameStatusChanged(_status, value);
            _status = value;
        }
    }

    private GameStatus _status { get; set; }

    public void OnGameStatusChanged(GameStatus oldStatus, GameStatus newStatus)
    {
        PlayerOne?.SendMessage($"Status changed from {oldStatus} to {newStatus}");
        PlayerTwo?.SendMessage($"Status changed to {oldStatus} to {newStatus}");
    }
}