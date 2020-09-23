using System;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Game.Client.Managers;

namespace Game.Client.ViewLogic
{
    public class SpawnShipViewInstruction : InstantInstruction
    {
        private readonly ShipViewManager shipViewManager;

        public SpawnShipViewInstruction(ShipViewManager shipViewManager)
        {
            Contract.IsNotNull(shipViewManager);

            this.shipViewManager = shipViewManager;
        }

        protected override void OnInstantStart()
        {
            shipViewManager.SpawnShipView();
        }
    }
}
