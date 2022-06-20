using System.Collections.Generic;
using System.Linq;

namespace RageServer.ColShapes.Base
{
    public static class BaseColShapeSystem
    {
        public static List<BaseColShape> ServerColShapes = new List<BaseColShape>();
        public static void AddColShape(BaseColShape colShape)
        {
            ServerColShapes.Add(colShape);
        }
        public static BaseColShape GetColShape(ushort colShapeId)
        {
            return ServerColShapes.FirstOrDefault(x => x.ColShape.Id == colShapeId);
        }
    }
}
