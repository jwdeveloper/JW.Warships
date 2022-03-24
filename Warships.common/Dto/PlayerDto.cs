using Microsoft.AspNetCore.SignalR;

namespace Warships.common.Dto;

public class PlayerDto
{
    public class Create
    {
        public string Name { get; set; }
        
        public string ConnectionId { get; set; }
        
        public IClientProxy ClientProxy { get; set; }
    }
}