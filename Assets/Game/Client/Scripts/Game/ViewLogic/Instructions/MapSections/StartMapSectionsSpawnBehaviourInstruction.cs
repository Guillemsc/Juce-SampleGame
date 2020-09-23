using System;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Game.Client.Managers;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public class StartMapSectionsSpawnBehaviourInstruction : InstantInstruction
    {
        private readonly ShipViewManager shipViewManager;
        private readonly MapSectionsSpawnBehaviour mapSectionsSpawnBehaviour;

        public StartMapSectionsSpawnBehaviourInstruction(ShipViewManager shipViewManager,
            MapSectionsSpawnBehaviour mapSectionsSpawnBehaviour)
        {
            Contract.IsNotNull(shipViewManager);
            Contract.IsNotNull(mapSectionsSpawnBehaviour);

            this.shipViewManager = shipViewManager;
            this.mapSectionsSpawnBehaviour = mapSectionsSpawnBehaviour;
        }

        protected override void OnInstantStart()
        {
            ShipView shipView = shipViewManager.GetShipView();

            mapSectionsSpawnBehaviour.Start(shipView);
        }
    }
}
