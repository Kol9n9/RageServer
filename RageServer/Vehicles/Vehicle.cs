using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
namespace RageServer.Vehicles
{
    public class Vehicle
    {
        public int Id { get; private set; }
        public int GameId { get; }
        public uint Model { get; }
        public Vector3 SpawnPosition { get; set; }
        public float SpawnRotation { get; set; }
        public GTANetworkAPI.Vehicle GameVehicle { get; }
        public Vehicle(int Id, int GameId, uint Model, GTANetworkAPI.Vehicle GameVehicle)
        {
            this.Id = Id;
            this.GameId = GameId;
            this.Model = Model;
            this.GameVehicle = GameVehicle;
        }
        public void SetId(int id)
        {
            if (Id != VehicleSystem.INVALID_VEHICLEID) return;
            Id = id;
        }
        public void SetPosition(Vector3 Position, float Rotation, uint VirtualWorld)
        {
            GameVehicle.Position = Position;
            GameVehicle.Rotation.Z = Rotation;
            GameVehicle.Dimension = VirtualWorld;
        }
    }
}
