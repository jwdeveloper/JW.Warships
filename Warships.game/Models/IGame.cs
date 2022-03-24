using Warships.game.Enums;

namespace Warships.game.Models.Player;

public interface IGame : IModel
{
     IList<ITour> Tours{ get; set; }

     IPlayer PlayerOne{ get; set; }

     IPlayer PlayerTwo{ get; set; }

     GameStatus Status { get; set; }

    

}