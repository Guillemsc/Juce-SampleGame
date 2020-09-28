using System;
using Juce.Core.Tickable;
using Juce.Core.Contexts;
using Juce.Core.EntryPoint;
using Juce.Core.Logic;
using Juce.Core.Services;
using Juce.Core.Service;
using Game.Client.Contexts;
using Game.Client.Managers;
using Game.Client.Services;
using Game.Shared;
using Game.Shared.Logic;

namespace Game.Client.ViewLogic
{
    public class GameDefaultEntryPoint : EntryPoint
    {
        protected override void OnExecute()
        {
            // References
            GameContext gameContext = ContextsProvider.Instance.GetContext<GameContext>();
            GameContextReferences gameContextReferences = gameContext.References;

            // Services
            CheatsService cheatsService = ServicesProvider.Instance.GetService<CheatsService>();
            TickablesService tickableService = ServicesProvider.Instance.GetService<TickablesService>();
            GameTimeService gameTimeService = ServicesProvider.Instance.GetService<GameTimeService>();

            // Shared Logic
            MatchLogicConfig matchLogicConfig = new MatchLogicConfig(gameContextReferences.MatchLogicSettings.MapSectionsConfig);
            MatchLogic matchLogic = new MatchLogic(matchLogicConfig);

            ILogicBridge<Message<MessageType>> logicBridge = new LocalLogicBridge(matchLogic.LogicBridge);

            // Dependency injection -----------------------------
            // --------------------------------------------------

            // Managers
            ShipViewManager shipViewManager = new ShipViewManager(
                gameContextReferences.WorldSettings,
                gameContextReferences.ShipViewSettings
                );

            MapSectionsManager mapSectionsManager = new MapSectionsManager(
                gameContextReferences.WorldSettings,
                gameContextReferences.MapSectionsSettings
                );

            CollectablesManager collectablesManager = new CollectablesManager(
                gameContextReferences.CollectablesSettings
                );

            PointLineViewManager pointLineViewManager = new PointLineViewManager(
                gameContextReferences.WorldSettings,
                gameContextReferences.PointLineViewSettings
                );

            PointsNumberViewManager pointsNumberViewManager = new PointsNumberViewManager(
                gameContextReferences.WorldSpaceUISettings,
                gameContextReferences.PointsNumberViewSettings
                );

            // Data
            BoolData shipCollidedData = new BoolData();

            // Cheats
            GodModeCheat godModeCheat = new GodModeCheat(logicBridge);
            cheatsService.PushCheats(godModeCheat);
            AddCleanUpAction(() => cheatsService.PopCheats(godModeCheat));

            // Behaviours
            InstructionsHandlerBehaviour instructionsHandlerBehaviour = new InstructionsHandlerBehaviour(
                tickableService
                );
            instructionsHandlerBehaviour.Enable();
            AddCleanUpAction(() => instructionsHandlerBehaviour.Disable());

            ShipViewMovementBehaviour shipViewMovementBehaviour = new ShipViewMovementBehaviour(
                tickableService,
                gameContextReferences.ShipViewMovementSettings
                );
            shipViewMovementBehaviour.Enable();
            AddCleanUpAction(() => shipViewMovementBehaviour.Disable());

            MapSectionsSpawnBehaviour mapSectionsSpawnBehaviour = new MapSectionsSpawnBehaviour(
                logicBridge,
                tickableService,
                gameContextReferences.MapSectionsSettings,
                mapSectionsManager,
                collectablesManager
                );
            mapSectionsSpawnBehaviour.Enable();
            AddCleanUpAction(() => mapSectionsSpawnBehaviour.Disable());

            MapSectionsDespawnBehaviour mapSectionsDespawnBehaviour = new MapSectionsDespawnBehaviour(
                tickableService,
                gameContextReferences.MapSectionsSettings,
                mapSectionsManager
                );
            mapSectionsDespawnBehaviour.Enable();
            AddCleanUpAction(() => mapSectionsDespawnBehaviour.Disable());

            CameraCollidersBehaviour cameraCollidersBehaviour = new CameraCollidersBehaviour(
                tickableService,
                gameContextReferences.WorldSettings,
                gameContextReferences.CamerasSettings,
                gameContextReferences.CameraCollidersSettings
                );
            cameraCollidersBehaviour.Enable();
            AddCleanUpAction(() => cameraCollidersBehaviour.Disable());

            PointLineSpawnBehaviour pointLineSpawnBehaviour = new PointLineSpawnBehaviour(
                tickableService,
                gameContextReferences.PointLineViewSettings,
                gameContextReferences.PointsNumberViewSettings,
                gameContextReferences.CamerasSettings,
                pointLineViewManager,
                pointsNumberViewManager
                );
            pointLineSpawnBehaviour.Enable();
            AddCleanUpAction(() => pointLineSpawnBehaviour.Disable());

            PointLineDespawnBehaviour pointLineDespawnBehaviour = new PointLineDespawnBehaviour(
                tickableService,
                gameContextReferences.PointLineViewSettings,
                pointLineViewManager,
                pointsNumberViewManager
                );
            pointLineDespawnBehaviour.Enable();
            AddCleanUpAction(() => pointLineDespawnBehaviour.Disable());

            // Input
            InputMaster inputMaster = new InputMaster();
            AddCleanUpAction(() => inputMaster.Disable());

            UserInput userInput = new UserInput(inputMaster);
            AddCleanUpAction(() => userInput.Disable());

            ShipViewCollisionsInput shipViewCollisionsInput = new ShipViewCollisionsInput();
            AddCleanUpAction(() => shipViewCollisionsInput.Disable());

            // Linker Actions
            GameLogicActions gameLogicActions = new GameLogicActions(
                matchSetup: new MatchSetupCompositeAction(
                        new IMatchSetupAction[]
                        {
                            new LoadScenarioMatchSetupAction(
                                instructionsHandlerBehaviour,
                                gameContext,
                                shipViewManager,
                                mapSectionsSpawnBehaviour,
                                mapSectionsDespawnBehaviour,
                                pointLineSpawnBehaviour,
                                pointLineDespawnBehaviour,
                                gameContextReferences.CamerasSettings
                                ),

                            new MarkContextAsReadyMatchSetupAction(
                                instructionsHandlerBehaviour,
                                gameContext
                                ),
                        }
                    ),

                matchStart: new MatchStartAction(
                    instructionsHandlerBehaviour,
                    gameTimeService,
                    gameContextReferences.DirectionBarSettings,
                    shipViewManager,
                    shipViewMovementBehaviour,
                    gameContextReferences.ViewModelsSettings.DirectionBarViewModel
                    ),

                matchEnded: new MatchEndedAction(
                    instructionsHandlerBehaviour,
                    gameContextReferences.ViewModelsSettings.LoseScreenViewModel
                    ),

                spawnMapSection: new SpawnMapSectionAction(
                    instructionsHandlerBehaviour,
                    mapSectionsSpawnBehaviour
                    ),

                shipDestroyed: new ShipDestroyedAction(
                    instructionsHandlerBehaviour,
                    shipViewManager,
                    shipViewMovementBehaviour,
                    gameContextReferences.FeedbacksSettings.ShipDestroyedWorldFeedback
                    )
                );

            PlayerInputActions playerInputActions = new PlayerInputActions(
                directionTrigger: new DirectionTriggerAction(
                    instructionsHandlerBehaviour,
                    shipViewMovementBehaviour,
                    gameContextReferences.ViewModelsSettings.DirectionBarViewModel
                    )
                );

            ShipCollisionsActions shipCollisionsActions = new ShipCollisionsActions(
                shipCollidedObstacle: new ShipCollidedObstacleAction(
                    logicBridge
                    ),

                shipCollidedCollectable: new ShipCollidedCollectableAction(
                    logicBridge,
                    instructionsHandlerBehaviour
                    ),

                shipCollidedPointLine: new ShipCollidedPointLineAction(
                    logicBridge
                    )
                );

            // Linkers
            GameLogicLinker gameLogicLinker = new GameLogicLinker(
                gameLogicActions,
                logicBridge
                );
            AddCleanUpAction(() => gameLogicLinker.CleanUp());

            PlayerInputLinker playerInputLinker = new PlayerInputLinker(
                playerInputActions,
                userInput
                );
            AddCleanUpAction(() => playerInputLinker.CleanUp());

            ShipCollisionsLinker shipCollisionsLinker = new ShipCollisionsLinker(
                shipCollisionsActions,
                shipViewCollisionsInput,
                shipCollidedData
                );
            AddCleanUpAction(() => shipCollisionsLinker.CleanUp());

            // --------------------------------------------------
            // --------------------------------------------------

            // Start
            matchLogic.Start();
        }
    }
}
