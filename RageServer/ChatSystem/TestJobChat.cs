using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageServer.ChatSystem
{
    public class TestJobChat : BaseChat
    {
        public TestJobChat(string Name) : base(Name)
        {

        }
        public override void SendChatMessage(Player player, string message)
        {
            string formatedMessage = $"~o~[{Name}]{player.Name}[{player.Id}]: {message}";
            foreach(var p in Players)
            {
                p.SendChatMessage(formatedMessage);
            }
        }
    }
}
