using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;

namespace RageServer.Data.Models
{
    [Serializable]
    public class VehicleModel
    {
        [Key]
        public int VehicleId { get; set; }
        public uint Model { get; set; }
        public Vector3 SpawnPosition { get; set; }
        public float SpawnRotation { get; set; }
    }
}
