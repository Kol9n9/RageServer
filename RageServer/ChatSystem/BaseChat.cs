using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using RageServer.AccountSystem;

namespace RageServer.ChatSystem
{
    public abstract class BaseChat 
    {
        private static int MaxChatId { get; set; }
        private static List<int> AvailableIDs { get; set; }
        public int Id { get; }
        protected string Name { get; }
        protected List<Account> Players { get; }
        public BaseChat(string Name)
        {
            if (AvailableIDs == null) AvailableIDs = new List<int>();
            this.Name = Name;
            Players = new List<Account>();
            Id = GetAvailableId();
        }
        private int GetAvailableId()
        {
            if(AvailableIDs.Count != 0)
            {
                int id = AvailableIDs[0];
                AvailableIDs.RemoveAt(0);
                return id;
            }
            return ++MaxChatId;
        }
        public static void DeleteChat(BaseChat chat)
        {
            AvailableIDs.Add(chat.Id);
            AvailableIDs.Sort();
        }
        public void AddPlayerToChat(Account player)
        {
            if (Players.Contains(player)) return;
            Players.Add(player);
        }
        public abstract void SendChatMessage(Account player, string message);
    }
}
