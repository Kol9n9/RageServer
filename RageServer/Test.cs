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
        [Command("window")]
        private void OnWindowCommand(Player player, bool status)
        {
            if (status) NAPI.ClientEvent.TriggerClientEvent(player, "TestWindowShow");
            else NAPI.ClientEvent.TriggerClientEvent(player, "TestWindowHide");
        }
    }
}
