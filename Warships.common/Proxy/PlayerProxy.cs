using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Warships.common.Dto;
using Warships.game.Models.Player;

namespace Warships.common.Proxy;

public class PlayerProxy : IPlayer
{
    public Guid Id { get; set; } = Guid.NewGuid();

    private readonly IClientProxy _connection;
    public string Name { get; set; }
    public DateTimeOffset JoinDate { get; set; }

    public PlayerProxy(IClientProxy connection)
    {
        _connection = connection;
    }

    public void SendMessage(string message)
    {
        Send(new Message.Response
        {
            Message = message,
            PlayerId = Id
        });
    }

    public async void Send<T>(T payLoad)
    {
        var json = JsonConvert.SerializeObject(payLoad);
       await _connection.SendAsync(json);
    }
}