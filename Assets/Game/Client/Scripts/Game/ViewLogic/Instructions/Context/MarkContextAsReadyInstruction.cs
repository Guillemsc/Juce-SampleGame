using System;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Game.Client.Contexts;

namespace Game.Client.ViewLogic
{
    public class MarkContextAsReadyInstruction : InstantInstruction
    {
        private readonly GameContext gameContext;

        public MarkContextAsReadyInstruction(GameContext gameContext)
        {
            Contract.IsNotNull(gameContext);

            this.gameContext = gameContext;
        }

        protected override void OnInstantStart()
        {
            gameContext.MarkAsReady();
        }
    }
}
