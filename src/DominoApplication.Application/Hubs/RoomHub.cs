using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DominoApplication.Application.Hubs
{
    public class RoomHub : Hub
    {

        public async Task JoinRoomAction(string roomId, string name, string status)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.Group(roomId).SendAsync("JoinRoom", Context.ConnectionId, name, status);
        }
    }
}
