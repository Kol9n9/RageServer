using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
namespace RageClient
{
    class Freeze : Events.Script
    {
        public Freeze()
        {
            RAGE.Events.Add("PlayerFreeze", OnPlayerFreeze);
        }

        private void OnPlayerFreeze(object[] args)
        {
            RAGE.Elements.Player.LocalPlayer.FreezePosition((bool)args[0]);

        }
    }
}
