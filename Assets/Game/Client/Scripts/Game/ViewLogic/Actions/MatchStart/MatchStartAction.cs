using System;
using Juce.Core.Sequencing;
using Game.Client.Managers;
using Game.Client.Settings;
using Game.Client.ViewModels;
using Game.Client.Services;

namespace Game.Client.ViewLogic
{
    public class MatchStartAction : IMatchStartAction
    {
        private readonly InstructionsHandlerBehaviour instructionHandler;
        private readonly GameTimeService gameTimeService;
        private readonly DirectionBarSettings directionBarSettings;
        private readonly ShipViewManager shipViewManager;
        private readonly ShipViewMovementBehaviour shipViewMovementBehaviour;
        private readonly DirectionBarViewModel directionBarViewModel;

        public MatchStartAction(InstructionsHandlerBehaviour instructionHandler,
            GameTimeService gameTimeService,
            DirectionBarSettings directionBarSettings,
            ShipViewManager shipViewManager,
            ShipViewMovementBehaviour shipViewMovementBehaviour,
            DirectionBarViewModel directionBarViewModel)
        {
            this.instructionHandler = instructionHandler;
            this.gameTimeService = gameTimeService;
            this.directionBarSettings = directionBarSettings;
            this.shipViewManager = shipViewManager;
            this.shipViewMovementBehaviour = shipViewMovementBehaviour;
            this.directionBarViewModel = directionBarViewModel;
        }

        public void Invoke()
        {
            InstructionsSequence sequence = new InstructionsSequence();

            //sequence.Append(new WaitTimeInstruction(1.0f));

            sequence.Append(new MoveShipViewToOffsetInstruction(shipViewManager));
            sequence.Append(new StartDirectionBarViewModel(directionBarViewModel, gameTimeService, directionBarSettings));
            sequence.Append(new StartShipMovementBehaviourInstruction(shipViewManager, shipViewMovementBehaviour));

            instructionHandler.EnqueueMainInstruction(sequence);
        }
    }
}
