using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DominoApplication.Application.Hubs
{
    public class RoomHub : Hub
    {


        public async Task JoinRoomAction(string roomId, string userId, string name, string status)
        {
            await Clients.Client(roomId).SendAsync("JoinRoom", userId, name, status);
        }
    }
}
