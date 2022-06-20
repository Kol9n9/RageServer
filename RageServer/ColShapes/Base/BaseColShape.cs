using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageServer.ColShapes
{
    public abstract class BaseColShape
    {
        public int Id { get; }
        public Vector3 Position { get; }
        public uint VirtualWorld { get; }
        public Action<Player> PlayerEvent { get; set; }
        public ColShape ColShape { get; }
        public float ColShapeRange { get; }
        public float ColShapeHeight { get; }
        public BaseColShape(int Id, Vector3 Position, uint VirtualWorld, float ColShapeRange = 5, float ColShapeHeight = 5, Action<Player> PlayerEvent = null)
        {
            this.Id = Id;
            this.Position = Position;
            this.VirtualWorld = VirtualWorld;
            this.PlayerEvent = PlayerEvent;
            this.ColShapeRange = ColShapeRange;
            this.ColShapeHeight = ColShapeHeight;
            this.ColShape = NAPI.ColShape.CreateCylinderColShape(this.Position, ColShapeRange, ColShapeHeight, VirtualWorld);
        }
    }
}
