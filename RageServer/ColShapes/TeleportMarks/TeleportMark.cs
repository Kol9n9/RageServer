using GTANetworkAPI;
using RageServer.ColShapes.Base;
using RageServer.Data.Enums;
using RageServer.Data.Repository;
using System;

namespace RageServer.ColShapes
{
    public class TeleportMark : BaseColShape
    {
        public Vector3 SpawnPosition { get; }
        public float SpawnRotation { get; }
        public uint SpawnVirtualWorld { get; }
        public TeleportTypeEnum TeleportType { get; }
        private Marker marker;

        public TeleportMark(int Id, Vector3 Position, uint VirtualWorld, 
            Vector3 SpawnPosition, float SpawnRotation, uint SpawnVirtualWorld,
            TeleportTypeEnum TeleportType) : 
            base(Id,Position,VirtualWorld)
        {
            this.SpawnPosition = SpawnPosition;
            this.SpawnRotation = SpawnRotation;
            this.SpawnVirtualWorld = SpawnVirtualWorld;
            this.TeleportType = TeleportType;
            marker = NAPI.Marker.CreateMarker(2, this.Position, new Vector3(1, 1, 1), new Vector3(1, 1, 1), 5, new Color(255, 255, 255), dimension: this.VirtualWorld);
            this.PlayerEvent = CreatePlayerEvent();
            BaseColShapeSystem.AddColShape(this);
        }
        private Action<Player> CreatePlayerEvent()
        {
            return (Player player) =>
            {
                switch (TeleportType)
                {
                    case TeleportTypeEnum.OnlyPlayer: TeleportOnlyPlayer(player);  break;
                    case TeleportTypeEnum.OnlyVehicle: TeleportOnlyVehicle(player); break;
                    case TeleportTypeEnum.OnlyPlayerInVehicle: TeleportOnlyInVehicle(player); break;
                    case TeleportTypeEnum.OnlyPlayerOrWithVehicle: TeleportOnlyPlayerOrWithVehicle(player); break;
                }
            };
        }
        private void TeleportOnlyPlayer(Player player)
        {
            if (player.IsInVehicle) return;
            var account = AccountSystem.AccountSystem.GetAccount(player);
            if (account == null) return;
            account.SetPosition(SpawnPosition, SpawnRotation, SpawnVirtualWorld);
        }
        private void TeleportOnlyVehicle(Player player)
        {
            if (!player.IsInVehicle) return;
            var veh = Vehicles.VehicleSystem.GetVehicle(player.Vehicle);
            if (veh == null) return;
            player.WarpOutOfVehicle();
            veh.SetPosition(SpawnPosition, SpawnRotation, SpawnVirtualWorld);
        }
        private void TeleportOnlyInVehicle(Player player)
        {
            if (!player.IsInVehicle) return;
            var veh = Vehicles.VehicleSystem.GetVehicle(player.Vehicle);
            if (veh == null) return;
            veh.SetPosition(SpawnPosition, SpawnRotation, SpawnVirtualWorld);
        }
        private void TeleportOnlyPlayerOrWithVehicle(Player player)
        {
            if (!player.IsInVehicle) TeleportOnlyPlayer(player);
            else TeleportOnlyInVehicle(player);
        }
        public static void LoadMarks()
        {
            TeleportMarkRepository markRepository = new TeleportMarkRepository();
            foreach (var mark in markRepository.GetAll())
            {
                new TeleportMark(mark.TeleportMarkId, Utils.Transforms.TransformVectors(mark.Position), mark.VirtualWorld,
                    Utils.Transforms.TransformVectors(mark.SpawnPosition), mark.SpawnRotation, mark.SpawnVirtualWorld, mark.TeleportType);
            }
        }
    }
}
