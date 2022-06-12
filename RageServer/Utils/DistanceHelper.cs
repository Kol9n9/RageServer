using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
namespace RageServer.Utils
{
    public static class DistanceHelper
    {
        public static List<Player> GetPlayersForRange(Vector3 point, double range)
        {
            List<Player> players = new List<Player>();

            foreach(var p in NAPI.Pools.GetAllPlayers())
            {
                if (GetPifagorValue(point.X - p.Position.X, point.Y - p.Position.Y, point.Z - p.Position.Z) <= range) players.Add(p);
            }
            return players;
        }
        private static double GetPifagorValue(double x, double y, double z) => Math.Sqrt((x * x) + (y * y) + (z * z));
    }
}
