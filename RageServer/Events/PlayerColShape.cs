using GTANetworkAPI;
using RageServer.ColShapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageServer.Events
{
    class PlayerColShape : Script
    {
        [ServerEvent(Event.PlayerEnterColshape)]
        private void OnPlayerEnterColshape(ColShape colShape, Player player)
        {
            var shape = BaseColShapeSystem.GetColShape(colShape.Id);
            if (shape == null) return;
            shape.PlayerEvent?.Invoke(player);
        }
    }
}
