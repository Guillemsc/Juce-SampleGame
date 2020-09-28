using System;
using Cinemachine;
using Juce.Core.Sequencing;
using Game.Client.Contexts;
using Game.Client.Managers;
using Game.Client.Settings;

namespace Game.Client.ViewLogic
{
    public class LoadScenarioMatchSetupAction : IMatchSetupAction
    {
        private readonly InstructionsHandlerBehaviour instructionHandler;
        private readonly GameContext gameContext;
        private readonly ShipViewManager shipViewManager;
        private readonly MapSectionsSpawnBehaviour mapSectionsSpawnBehaviour;
        private readonly MapSectionsDespawnBehaviour mapSectionsDespawnBehaviour;
        private readonly PointLineSpawnBehaviour pointLineSpawnBehaviour;
        private readonly PointLineDespawnBehaviour pointLineDespawnBehaviour;
        private readonly CamerasSettings cameraSettings;

        public LoadScenarioMatchSetupAction(
            InstructionsHandlerBehaviour instructionHandler,
            GameContext gameContext, ShipViewManager shipViewManager,
            MapSectionsSpawnBehaviour mapSectionsSpawnBehaviour,
            MapSectionsDespawnBehaviour mapSectionsDespawnBehaviour,
            PointLineSpawnBehaviour pointLineSpawnBehaviour,
            PointLineDespawnBehaviour pointLineDespawnBehaviour,
            CamerasSettings cameraSettings)
        {
            this.instructionHandler = instructionHandler;
            this.gameContext = gameContext;
            this.shipViewManager = shipViewManager;
            this.mapSectionsSpawnBehaviour = mapSectionsSpawnBehaviour;
            this.mapSectionsDespawnBehaviour = mapSectionsDespawnBehaviour;
            this.pointLineSpawnBehaviour = pointLineSpawnBehaviour;
            this.pointLineDespawnBehaviour = pointLineDespawnBehaviour;
            this.cameraSettings = cameraSettings;
        }

        public void Invoke()
        {
            InstructionsSequence sequence = new InstructionsSequence();

            sequence.Append(new SpawnShipViewInstruction(shipViewManager));
            sequence.Append(new AttachCameraToShipViewInstruction(shipViewManager, cameraSettings.ShipViewVirtualCamera));

            sequence.Append(new StartMapSectionsSpawnBehaviourInstruction(shipViewManager, mapSectionsSpawnBehaviour));
            sequence.Append(new StartMapSectionsDespawnBehaviourInstruction(shipViewManager, mapSectionsDespawnBehaviour));

            //sequence.Append(new StartPointLineSpawnBehaviourInstruction(shipViewManager, pointLineSpawnBehaviour));
            sequence.Append(new StartPointLineDespawnBehaviourInstruction(shipViewManager, pointLineDespawnBehaviour));

            instructionHandler.EnqueueMainInstruction(sequence);
        }
    }
}
