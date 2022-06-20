using RAGE;

namespace RageClient
{
    class TestCreateTeleportMark : Events.Script
    {
        private Vector3 Position;
        private uint VirtualVoid;
        private bool isCreating = false;
        public TestCreateTeleportMark()
        {
            RAGE.Events.OnPlayerCommand += OnPlayerCommand;
        }

        private void OnPlayerCommand(string cmd, Events.CancelEventArgs cancel)
        {
            if(cmd == "tpcreate")
            {
                Position = RAGE.Elements.Player.LocalPlayer.Position;
                Position.Z -= RAGE.Elements.Player.LocalPlayer.GetHeightAboveGround();
                VirtualVoid = RAGE.Elements.Player.LocalPlayer.Dimension;
                isCreating = true;
                
            }
            else if(cmd == "save")
            {
                if (!isCreating) return;
                RAGE.Events.CallRemote("PlayerCreatedTeleportMark", RAGE.Util.Json.Serialize(Position), VirtualVoid, 0);
                isCreating = false;
            }
        }
    }
}
