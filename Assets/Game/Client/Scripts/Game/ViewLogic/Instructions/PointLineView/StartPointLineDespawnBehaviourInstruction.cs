using System;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Game.Client.Managers;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public class StartPointLineDespawnBehaviourInstruction : InstantInstruction
    {
        private readonly ShipViewManager shipViewManager;
        private readonly PointLineDespawnBehaviour pointLineDespawnBehaviour;

        public StartPointLineDespawnBehaviourInstruction(ShipViewManager shipViewManager,
            PointLineDespawnBehaviour pointLineDespawnBehaviour)
        {
            Contract.IsNotNull(shipViewManager);
            Contract.IsNotNull(pointLineDespawnBehaviour);

            this.shipViewManager = shipViewManager;
            this.pointLineDespawnBehaviour = pointLineDespawnBehaviour;
        }

        protected override void OnInstantStart()
        {
            ShipView shipView = shipViewManager.GetShipView();

            pointLineDespawnBehaviour.Start(shipView);
        }
    }
}
