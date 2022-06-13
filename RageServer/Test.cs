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
        
        public Test()
        {
            
        }
        [Command("freeze")]
        private void OnFreezeCommand(Player player, bool status)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "PlayerFreeze", status);
        }
    }
}
