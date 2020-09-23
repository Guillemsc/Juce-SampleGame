using System;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Game.Client.ViewModels;

namespace Game.Client.ViewLogic
{
    public class SetShipViewRotationFromDirectionBarInstruction : InstantInstruction
    {
        private readonly ShipViewMovementBehaviour shipViewMovementBehaviour;
        private readonly DirectionBarViewModel directionBarViewModel;

        public SetShipViewRotationFromDirectionBarInstruction(ShipViewMovementBehaviour shipViewMovementBehaviour,
            DirectionBarViewModel directionBarViewModel)
        {
            Contract.IsNotNull(shipViewMovementBehaviour);
            Contract.IsNotNull(directionBarViewModel);

            this.shipViewMovementBehaviour = shipViewMovementBehaviour;
            this.directionBarViewModel = directionBarViewModel;
        }

        protected override void OnInstantStart()
        {
            float fillValue = directionBarViewModel.FillValue;

            shipViewMovementBehaviour.SetSteeringAngleFromNormalizedValue(fillValue);
        }
    }
}
