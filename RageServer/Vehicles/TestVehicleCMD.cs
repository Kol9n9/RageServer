using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageServer.Vehicles
{
    class TestVehicleCMD : Script
    {
        [Command("veh")]
        private void OnVehCmd(Player player, string model)
        {
            uint hash = NAPI.Util.GetHashKey(model);
            var veh = VehicleSystem.AddVehicle(hash, player.Position, player.Rotation.Z, VehicleSystem.CreateVehicleType.Temporary);
            player.SetIntoVehicle(veh.GameVehicle, (int)VehicleSeat.Driver);
        }
        [Command("createveh")]
        private void InCreateVehCmd(Player player)
        {
            if (!player.IsInVehicle)
            {
                player.SendChatMessage("Вы должны быть в тс");
                return;
            }
            var veh = VehicleSystem.GetVehicle(player.Vehicle);
            if(veh.Id != VehicleSystem.INVALID_VEHICLEID)
            {
                player.SendChatMessage("Данный тс невозможно добавить");
                return;
            }
            var position = veh.GameVehicle.Position;
            var rotation = veh.GameVehicle.Rotation.Z;
            player.WarpOutOfVehicle();
            VehicleSystem.RemoveVehicle(veh);
            var createVeh = VehicleSystem.AddVehicle(veh.Model, position, rotation, VehicleSystem.CreateVehicleType.Constant);
            player.SetIntoVehicle(createVeh.GameVehicle, (int)VehicleSeat.Driver);
            player.SendChatMessage("Вы создали новый тс");
        }
        [Command("dropveh")]
        private void InDropVehCmd(Player player)
        {
            if (!player.IsInVehicle)
            {
                player.SendChatMessage("Вы должны быть в тс");
                return;
            }
            var veh = VehicleSystem.GetVehicle(player.Vehicle);
            if (veh.Id == VehicleSystem.INVALID_VEHICLEID)
            {
                player.SendChatMessage("Данный тс невозможно удалить");
                return;
            }
            player.WarpOutOfVehicle();
            VehicleSystem.DropVehicle(veh);
            player.SendChatMessage("Вы удалили тс");
        }
    }
}
