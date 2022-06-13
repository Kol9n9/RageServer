using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
namespace RageServer.AccountSystem
{
    public class Account
    {
        public int Id { get; }
        public int GameId { get; }
        public string Nickname { get; set; }
        public int Money { get; set; }
        public Player GamePlayer {get;}
        public Account(int Id, int GameId, Player GamePlayer)
        {
            this.Id = Id;
            this.GameId = GameId;
            this.GamePlayer = GamePlayer;
        }
        
    }
}
