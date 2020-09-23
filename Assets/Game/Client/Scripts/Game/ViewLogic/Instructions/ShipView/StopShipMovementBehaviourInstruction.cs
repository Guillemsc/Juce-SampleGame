using System;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Game.Client.Managers;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public class StopShipMovementBehaviourInstruction : InstantInstruction
    {
        private readonly ShipViewManager shipViewManager;
        private readonly ShipViewMovementBehaviour shipViewMovementBehaviour;

        public StopShipMovementBehaviourInstruction(ShipViewManager shipViewManager,
            ShipViewMovementBehaviour shipViewMovementBehaviour)
        {
            Contract.IsNotNull(shipViewManager);
            Contract.IsNotNull(shipViewMovementBehaviour);

            this.shipViewManager = shipViewManager;
            this.shipViewMovementBehaviour = shipViewMovementBehaviour;
        }

        protected override void OnInstantStart()
        {
            ShipView shipView = shipViewManager.GetShipView();

            shipViewMovementBehaviour.StopMoving(shipView);
        }
    }
}
