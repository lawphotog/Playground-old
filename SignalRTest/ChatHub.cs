using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApplication1
{
    [HubName("chart")]
    public class ChatHub : Hub
    {
        public void Send(int value)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.Value(value);            
        }
    }
}