namespace Warships.game.Models.Player;

public interface IPlayer : IModel
{
    public string Name { get; set; }

    public void Send<T>(T payLoad);

    public void SendMessage(string message);
}