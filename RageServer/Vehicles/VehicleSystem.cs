using RageServer.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using System.Linq;

namespace RageServer.Vehicles
{
    public static class VehicleSystem
    {
        public static readonly int INVALID_VEHICLEID = -1;
        public static List<Vehicle> Vehicles = new List<Vehicle>();
        private static List<int> availableIds = new List<int>();
        private static VehicleRepository vehicleRepository = new VehicleRepository();

        private static readonly string KeyID = "ID";
        private static readonly string KeyGameID = "GameID";
        public static void LoadVehicles()
        {
            foreach(var vehicle in vehicleRepository.GetAll())
            {
                var vector = Utils.Transforms.TransformVectors(vehicle.SpawnPosition);
                var veh = CreateVehicle(vehicle.Model, vector, vehicle.SpawnRotation, 0, 0);
                int gameId = GetCurrentGameVehicleId();
                veh.SetSharedData(KeyID, vehicle.VehicleId);
                veh.SetSharedData(KeyGameID, gameId);
                Vehicles.Add(new Vehicle(vehicle.VehicleId, gameId, vehicle.Model, veh)
                {
                    SpawnPosition = vector,
                    SpawnRotation = vehicle.SpawnRotation
                });
            }
        }
        public static void SaveVehicle(Vehicle vehicle)
        {
            var vector = Utils.Transforms.TransformVectors(vehicle.SpawnPosition);
            var vehModel = vehicleRepository.Get(x => x.VehicleId == vehicle.Id);
            vehModel.SpawnPosition = vector;
            vehModel.SpawnRotation = vehicle.SpawnRotation;
            vehicleRepository.Update(vehModel);
        }
        public static Vehicle AddVehicle(uint model, Vector3 position, float rotation, CreateVehicleType createVehicleType, bool IsAddToList = true)
        {

            var createdVeh = CreateVehicle(model, position, rotation, 0, 0);
            int vehId = INVALID_VEHICLEID;
            if(createVehicleType == CreateVehicleType.Constant)
            {
                Data.Models.VehicleModel vehicleModel = new Data.Models.VehicleModel()
                {
                    Model = model,
                    SpawnPosition = Utils.Transforms.TransformVectors(position),
                    SpawnRotation = rotation
                };
                vehicleRepository.Add(vehicleModel);
                vehId = vehicleModel.VehicleId;
                createdVeh.SetSharedData(KeyID, vehId);
            }
            int gameId = GetCurrentGameVehicleId();
            Vehicle vehicle = new Vehicle(vehId, gameId, model, createdVeh)
            {
                SpawnPosition = position,
                SpawnRotation = rotation
            };
            createdVeh.SetSharedData(KeyGameID, gameId);
            if (IsAddToList) Vehicles.Add(vehicle);
            return vehicle;
        }
        public static Vehicle GetVehicle(GTANetworkAPI.Vehicle GameVehicle)
        {
            if (!CheckIsExistVehicleGameId(GameVehicle)) return null;
            int gameId = GameVehicle.GetSharedData<int?>(KeyGameID).Value;
            return Vehicles.FirstOrDefault(x => x.GameId == gameId);
        }
        public static void RemoveVehicle(Vehicle vehicle)
        {
            availableIds.Add(vehicle.GameId);
            Vehicles.Remove(vehicle);
            vehicle.GameVehicle.Delete();
        }
        public static void DropVehicle(Vehicle vehicle)
        {
            RemoveVehicle(vehicle);
            vehicleRepository.Remove(vehicleRepository.Get(x => x.VehicleId == vehicle.Id));
        }
        private static bool CheckIsExistVehicleGameId(GTANetworkAPI.Vehicle GameVehicle)
        {
            return GameVehicle.GetSharedData<int?>(KeyGameID).HasValue;
        }
        private static GTANetworkAPI.Vehicle CreateVehicle(uint Model, Vector3 Position, float Rotation, int Color1, int Color2)
        {
            return NAPI.Vehicle.CreateVehicle(Model, Position, Rotation, Color1, Color2);
        }
        private static int GetCurrentGameVehicleId()
        {
            if(availableIds.Count != 0)
            {
                int id = availableIds[0];
                availableIds.RemoveAt(0);
                return id;
            }
            return Vehicles.Count+1;
        }
        public enum CreateVehicleType
        {
            /// <summary>
            /// Временный
            /// </summary>
            Temporary,
            /// <summary>
            /// Постоянный
            /// </summary>
            Constant
        }
    }
}
