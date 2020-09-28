using System;
using Juce.Core.Sequencing;
using Game.Client.ViewModels;

namespace Game.Client.ViewLogic
{
    public class MatchEndedAction : IMatchEndedAction
    {
        private readonly InstructionsHandlerBehaviour instructionHandler;
        private readonly LoseScreenViewModel loseScreenViewModel;

        public MatchEndedAction(InstructionsHandlerBehaviour instructionHandler, LoseScreenViewModel loseScreenViewModel)
        {
            this.instructionHandler = instructionHandler;
            this.loseScreenViewModel = loseScreenViewModel;
        }

        public void Invoke()
        {
            InstructionsSequence sequence = new InstructionsSequence();

            //sequence.Append(new WaitTimeInstruction(0.3f));
            sequence.Append(new ShowLoseScreenViewModelInstruction(loseScreenViewModel));

            instructionHandler.EnqueueMainInstruction(sequence);

        }
    }
}
