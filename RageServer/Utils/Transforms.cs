using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageServer.Utils
{
    public static class Transforms
    {

        public static Vector3 TransformVectors(System.Numerics.Vector3 vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }
        public static System.Numerics.Vector3 TransformVectors(Vector3 vector)
        {
            return new System.Numerics.Vector3(vector.X, vector.Y, vector.Z);
        }
    }
}
