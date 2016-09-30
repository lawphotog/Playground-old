using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.Hubs
{
    //[HubName("perfHub")]
    public class MyHub1 : Hub
    {
        public void Hello()
        {
            Clients.All.hello("Hello World!");
        }

        public void Send(string message)
        {
            Clients.All.newMessage(message);
        }
    }
}