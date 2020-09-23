using System;
using Juce.Core.Sequencing;
using Game.Client.Contexts;

namespace Game.Client.ViewLogic
{
    public class MarkContextAsReadyMatchSetupAction : IMatchSetupAction
    {
        private readonly InstructionsHandlerBehaviour instructionHandler;
        private readonly GameContext gameContext;

        public MarkContextAsReadyMatchSetupAction(InstructionsHandlerBehaviour instructionHandler,
            GameContext gameContext)
        {
            this.instructionHandler = instructionHandler;
            this.gameContext = gameContext;
        }

        public void Invoke()
        {
            InstructionsSequence sequence = new InstructionsSequence();

            sequence.Append(new MarkContextAsReadyInstruction(gameContext));

            instructionHandler.EnqueueMainInstruction(sequence);
        }
    }
}
