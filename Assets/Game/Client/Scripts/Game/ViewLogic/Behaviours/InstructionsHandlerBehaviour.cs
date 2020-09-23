using System;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Juce.Core.Tickable;
using Juce.Core.Services;

namespace Game.Client.ViewLogic
{
    public class InstructionsHandlerBehaviour : Juce.Core.ViewLogic.Behaviour, ITickable
    {
        private readonly TickablesService tickableService;
        private readonly InstructionsPlayer mainInstructionPlayer = new InstructionsPlayer();

        public InstructionsHandlerBehaviour(TickablesService tickableService)
        {
            Contract.IsNotNull(tickableService);

            this.tickableService = tickableService;
        }

        protected override void OnEnable()
        {
            tickableService.AddTickable(this);
        }

        protected override void OnDisable()
        {
            tickableService.RemoveTickable(this);
        }

        public void Tick()
        {
            mainInstructionPlayer.Update();
        }

        public void EnqueueMainInstruction(Instruction instruction)
        {
            mainInstructionPlayer.Play(instruction);
        }
    }
}
