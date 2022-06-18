using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
namespace RageServer
{
    /// <summary>
    /// Точка входа
    /// </summary>
    class Startup : Script
    {
        private readonly int major = 0;
        private readonly int minor = 0;
        private readonly int realese = 0;
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            NAPI.Server.SetGlobalServerChat(false);
            NAPI.Server.SetGlobalDefaultCommandMessages(false);
            NAPI.Util.ConsoleOutput("Запуск сервера...");
            Vehicles.VehicleSystem.LoadVehicles();
        }
    }
}
