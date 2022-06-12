using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageServer.ChatSystem
{
    public class ActionChat : BaseChat
    {
        private readonly double range;
        public ActionChat(double Range) : base("Чат действий")
        {
            range = Range;
        }
        public override void SendChatMessage(Player player, string message)
        {
            string formatedMessage = $"~b~{player.Name} {message}";
            foreach (var p in Utils.DistanceHelper.GetPlayersForRange(player.Position, range))
            {
                p.SendChatMessage(formatedMessage);
            }
        }
    }
}
