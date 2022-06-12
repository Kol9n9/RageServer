using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using RageServer.ChatSystem;

namespace RageServer
{
    /// <summary>
    /// Класс для проверки разрабатываемого функционала
    /// </summary>
    class Test : Script
    {
        private readonly List<TestJobChat> jobChats;
        public Test()
        {
            jobChats = new List<TestJobChat>();
        }
        [ServerEvent(Event.PlayerConnected)]
        private void OnPlayerConnected(Player player)
        {
            player.SendChatMessage("OnPlayerConnected");
        }
        
        [Command("j",GreedyArg = true)]
        private void SendJobChatMessage(Player player, int Id, string message)
        {
            TestJobChat chat = jobChats.Find(x => x.Id == Id);
            if(chat == null)
            {
                player.SendChatMessage("Данный чат не найден");
                return;
            }
            chat.SendChatMessage(player, message);
        }
        [Command("jc")]
        private void CreateJobChat(Player player, string name)
        {
            TestJobChat chat = new TestJobChat(name);
            chat.AddPlayerToChat(player);
            player.SendChatMessage($"Вы создали чат с Id = ~g~{chat.Id} ");
        }
        [Command("ji")]
        private void ConnectToJobChat(Player player, int Id)
        {
            TestJobChat chat = jobChats.Find(x => x.Id == Id);
            if (chat == null)
            {
                player.SendChatMessage("Данный чат не найден");
                return;
            }
            chat.AddPlayerToChat(player);
            player.SendChatMessage($"Вы присоединились к чату с Id = ~g~{chat.Id} ");
        }
    }
}
