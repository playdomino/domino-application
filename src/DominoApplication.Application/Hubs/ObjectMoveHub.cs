using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DominoApplication.Application.Infrastructure
{
    public class ObjectMoveHub : Hub
    {
        public async Task SendObjectMoveAction(string roomId, string objectId, string action)
        {
            await Clients.All.SendAsync("ObjectMoved", roomId, objectId, action);
        }
    }
}
