﻿using Microsoft.AspNetCore.SignalR;

namespace Whatsapp_Clone_api.Hubs
{
    public class ChatHub: Hub
    {
        public async Task UpdateMessages()
        {
            Console.WriteLine("hi chen");
        }
    }
}
