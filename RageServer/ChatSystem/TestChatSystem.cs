using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace RageServer.ChatSystem
{
    class TestChatSystem : Script
    {
        private readonly List<TestJobChat> jobChats;
        public TestChatSystem()
        {
            jobChats = new List<TestJobChat>();
            jobChats.Add(new TestJobChat("Созданный"));
        }
        [Command("j", GreedyArg = true)]
        private void SendJobChatMessage(Player player, int Id, string message)
        {
            TestJobChat chat = jobChats.Find(x => x.Id == Id);
            if (chat == null)
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
            jobChats.Add(chat);
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
