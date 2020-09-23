using System;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Game.Client.Managers;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public class StartMapSectionsDespawnBehaviourInstruction : InstantInstruction
    {
        private readonly ShipViewManager shipViewManager;
        private readonly MapSectionsDespawnBehaviour mapSectionsDespawnBehaviour;

        public StartMapSectionsDespawnBehaviourInstruction(ShipViewManager shipViewManager,
            MapSectionsDespawnBehaviour mapSectionsDespawnBehaviour)
        {
            Contract.IsNotNull(shipViewManager);
            Contract.IsNotNull(mapSectionsDespawnBehaviour);

            this.shipViewManager = shipViewManager;
            this.mapSectionsDespawnBehaviour = mapSectionsDespawnBehaviour;
        }

        protected override void OnInstantStart()
        {
            ShipView shipView = shipViewManager.GetShipView();

            mapSectionsDespawnBehaviour.Start(shipView);
        }
    }
}
