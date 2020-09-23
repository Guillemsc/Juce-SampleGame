using System;
using Juce.Core.Sequencing;
using Game.Client.ViewModels;

namespace Game.Client.ViewLogic
{
    public class DirectionTriggerAction : IDirectionTriggerAction
    {
        private readonly InstructionsHandlerBehaviour instructionHandler;
        private readonly ShipViewMovementBehaviour shipViewMovementBehaviour;
        private readonly DirectionBarViewModel directionBarViewModel;

        public DirectionTriggerAction(
            InstructionsHandlerBehaviour instructionHandler,
            ShipViewMovementBehaviour shipViewMovementBehaviour,
            DirectionBarViewModel directionBarViewModel)
        {
            this.instructionHandler = instructionHandler;
            this.shipViewMovementBehaviour = shipViewMovementBehaviour;
            this.directionBarViewModel = directionBarViewModel;
        }

        public void Invoke()
        {
            InstructionsSequence sequence = new InstructionsSequence();

            sequence.Append(new SetShipViewRotationFromDirectionBarInstruction(shipViewMovementBehaviour,
                directionBarViewModel));

            instructionHandler.EnqueueMainInstruction(sequence);
        }
    }
}
