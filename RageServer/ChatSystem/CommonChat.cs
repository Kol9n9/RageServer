using GTANetworkAPI;
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
        public override void SendChatMessage(Player player, string message)
        {
            string formatedMessage = $"{player.Name}[{player.Id}]: {message}";
            foreach(var p in Utils.DistanceHelper.GetPlayersForRange(player.Position, range))
            {
                p.SendChatMessage(formatedMessage);
            }
        }
    }
}
