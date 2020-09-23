using System;
using Game.Shared.Objects;

namespace Game.Client.ViewLogic
{
    public class SpawnMapSectionAction : ISpawnMapSectionAction
    {
        private readonly InstructionsHandlerBehaviour instructionsHandlerBehaviour;
        private readonly MapSectionsSpawnBehaviour mapSectionsSpawnBehaviour;

        public SpawnMapSectionAction(InstructionsHandlerBehaviour instructionsHandlerBehaviour,
            MapSectionsSpawnBehaviour mapSectionsSpawnBehaviour)
        {
            this.instructionsHandlerBehaviour = instructionsHandlerBehaviour;
            this.mapSectionsSpawnBehaviour = mapSectionsSpawnBehaviour;
        }

        public void Invoke(MapSection mapSection)
        {
            mapSectionsSpawnBehaviour.AddNextSectionToSpawn(mapSection);
        }
    }
}
