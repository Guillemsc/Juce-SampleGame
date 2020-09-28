using System;
using Juce.Feedbacks;
using Juce.Core.Sequencing;
using Game.Client.Managers;

namespace Game.Client.ViewLogic
{
    public class ShipDestroyedAction : IShipDestroyedAction
    {
        private readonly InstructionsHandlerBehaviour instructionHandler;
        private readonly ShipViewManager shipViewManager;
        private readonly ShipViewMovementBehaviour shipViewMovementBehaviour;
        private readonly FeedbacksPlayer shipDestroyedWorldFeedback;

        public ShipDestroyedAction(InstructionsHandlerBehaviour instructionHandler,
            ShipViewManager shipViewManager,
            ShipViewMovementBehaviour shipViewMovementBehaviour,
            FeedbacksPlayer shipDestroyedWorldFeedback)
        {
            this.instructionHandler = instructionHandler;
            this.shipViewManager = shipViewManager;
            this.shipViewMovementBehaviour = shipViewMovementBehaviour;
            this.shipDestroyedWorldFeedback = shipDestroyedWorldFeedback;
        }

        public void Invoke()
        {
            InstructionsSequence sequence = new InstructionsSequence();

            sequence.Append(new StopShipMovementBehaviourInstruction(shipViewManager, shipViewMovementBehaviour));

            sequence.JoinCallback(() =>
            {
                //shipDestroyedWorldFeedback.Play().ExecuteAsync();
            });

            instructionHandler.EnqueueMainInstruction(sequence);
        }
    }
}
