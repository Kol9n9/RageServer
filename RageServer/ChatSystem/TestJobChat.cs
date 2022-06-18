using GTANetworkAPI;
using RageServer.AccountSystem;
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
        public override void SendChatMessage(Account player, string message)
        {
            string formatedMessage = $"~o~[{Name}]{player.Nickname}[{player.Id}]: {message}";
            foreach(var p in Players)
            {
                p.GamePlayer.SendChatMessage(formatedMessage);
            }
        }
    }
}
