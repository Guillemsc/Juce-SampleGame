using System;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public class DespawnCollectableInstruction : InstantInstruction
    {
        private readonly CollectableView collectableView;

        public DespawnCollectableInstruction(CollectableView collectableView)
        {
            Contract.IsNotNull(collectableView);

            this.collectableView = collectableView;
        }

        protected override void OnInstantStart()
        {
            collectableView.gameObject.Destroy();
        }
    }
}
