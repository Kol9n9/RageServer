using GTANetworkAPI;
using RageServer.AccountSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageServer.ChatSystem
{
    public class CommonChat : BaseChat
    {
        private double range;
        public CommonChat(double Range) : base("Общий чат")
        {
            range = Range;
        }
        public override void SendChatMessage(Account player, string message)
        {
            string formatedMessage = $"{player.Nickname}[{player.GameId}]: {message}";
            foreach(var p in Utils.DistanceHelper.GetPlayersForRange(player.GamePlayer.Position, range))
            {
                p.SendChatMessage(formatedMessage);
            }
        }
    }
}
