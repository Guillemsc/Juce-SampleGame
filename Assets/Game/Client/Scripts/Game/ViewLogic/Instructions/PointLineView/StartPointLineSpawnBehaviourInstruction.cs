using System;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Game.Client.Managers;
using Game.Client.View;
using Game.Client.ViewLogic;

namespace SampleGame.Game.ViewLogic
{
    public class StartPointLineSpawnBehaviourInstruction : InstantInstruction
    {
        private readonly ShipViewManager shipViewManager;
        private readonly PointLineSpawnBehaviour pointLineSpawnBehaviour;

        public StartPointLineSpawnBehaviourInstruction(ShipViewManager shipViewManager,
            PointLineSpawnBehaviour pointLineSpawnBehaviour)
        {
            Contract.IsNotNull(shipViewManager);
            Contract.IsNotNull(pointLineSpawnBehaviour);

            this.shipViewManager = shipViewManager;
            this.pointLineSpawnBehaviour = pointLineSpawnBehaviour;
        }

        protected override void OnInstantStart()
        {
            ShipView shipView = shipViewManager.GetShipView();

            pointLineSpawnBehaviour.Start(shipView);
        }
    }
}
