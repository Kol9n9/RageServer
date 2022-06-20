using GTANetworkAPI;
using RageServer.Data.Enums;
using System.Text.Json;

namespace RageServer.ColShapes.TeleportMarks
{
    class TeleportMarkEvents : Script
    {
        [RemoteEvent("PlayerCreatedTeleportMark")]
        private void OnPlayerCreateTeleportMark(Player player, string JsonPosition, uint VirtualVoid, int TeleportType)
        {
            Vector3 Position = NAPI.Util.FromJson<Vector3>(JsonPosition);
            TeleportMark.CreateMark(Position, VirtualVoid, player.Position, player.Rotation.Z, player.Dimension, (TeleportTypeEnum)TeleportType);
        }
    }
}
