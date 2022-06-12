using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace RageServer
{
    /// <summary>
    /// Класс для проверки разрабатываемого функционала
    /// </summary>
    class Test : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        private void OnPlayerConnected(Player player)
        {
            player.SendChatMessage("OnPlayerConnected");
        }
    }
}
