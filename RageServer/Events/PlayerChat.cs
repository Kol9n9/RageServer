using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using RageServer.ChatSystem;

namespace RageServer.Events
{
    class PlayerChat : Script
    {
        private readonly CommonChat commonChat;
        private readonly ActionChat actionChat;
        public PlayerChat()
        {
            commonChat = new CommonChat(25);
            actionChat = new ActionChat(25);
        }

        [ServerEvent(Event.ChatMessage)]
        private void OnChatMessage(Player player, string message)
        {
            if (!AccountSystem.AccountSystem.CheckIsAccountLogged(player)) return;
            commonChat.SendChatMessage(AccountSystem.AccountSystem.GetAccount(player), message);
        }
        [Command("me",GreedyArg = true)]
        private void OnMeCommand(Player player, string message)
        {
            if (!AccountSystem.AccountSystem.CheckIsAccountLogged(player)) return;
            actionChat.SendChatMessage(AccountSystem.AccountSystem.GetAccount(player), message);
        }
    }
}
