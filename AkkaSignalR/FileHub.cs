using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.IO;
using Microsoft.AspNet.SignalR.Hubs;

namespace AkkaSignalR
{
    [HubName("file")]
    public class FileHub : Hub
    {
        public void Start()
        {
            int count = 0;
            var memoryfiles = new List<string>();

            var path = "C:\\Temp\\LoadComplete";
            var files = Directory.EnumerateFiles(path, "*.xml", SearchOption.AllDirectories);
                        
            foreach (string file in files)
            {
                memoryfiles.Add(file);
                count++;
                Clients.All.Count(count);
            }            
        }        
    }
}