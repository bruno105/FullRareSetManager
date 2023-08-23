using System;
using System.Threading;
using System.Windows.Forms;
using ExileCore;
using ExileCore.Shared;
using ExileCore.PoEMemory.MemoryObjects;
using FullRareSetManager.Utilities;
using SharpDX;
using System.Collections;
using System.Collections.Generic;

namespace FullRareSetManager
{
    public class DropAllToInventory
    {
        private const int WHILE_DELAY = 5;
        private readonly FullRareSetManagerCore _plugin;

        public DropAllToInventory(FullRareSetManagerCore plugin)
        {
            _plugin = plugin;
        }

        private GameController GameController => _plugin.GameController;

 

        public bool SwitchToTabByIndex(int tabIndex)
        {
            var indexOfCurrentVisibleTab = GameController.Game.IngameState.IngameUi.StashElement.IndexVisibleStash;
            var travelDistance = tabIndex - indexOfCurrentVisibleTab;
            var tabIsToTheLeft = travelDistance < 0;
            travelDistance = Math.Abs(travelDistance);          

            _plugin.LogError($"Trying switch From: {indexOfCurrentVisibleTab}  TO From: {tabIndex}");
            
            string pressing = tabIsToTheLeft ? "Left" : "Right";
            _plugin.LogError($"Tavel Distance {travelDistance}  Direction: {pressing}");
            for (var i = 0; i < travelDistance; i++)
            {

                Keyboard.KeyPress(tabIsToTheLeft ? Keys.Left : Keys.Right);
                Thread.Sleep(_plugin.Settings.ExtraDelay + 100);

            }


            return true;
        }



    }
}
