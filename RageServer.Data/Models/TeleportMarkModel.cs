using RageServer.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace RageServer.Data.Models
{
    public class TeleportMarkModel
    {
        [Key]
        public int TeleportMarkId { get; set; }
        public Vector3 Position { get; set; }
        public uint VirtualWorld { get; set; }
        public Vector3 SpawnPosition { get; set; }
        public float SpawnRotation { get; set; }
        public uint SpawnVirtualWorld { get; set; }
        public TeleportTypeEnum TeleportType { get; set; }
    }
}
