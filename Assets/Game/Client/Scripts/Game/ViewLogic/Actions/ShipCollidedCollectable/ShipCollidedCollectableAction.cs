using System;
using Juce.Core.Logic;
using Juce.Core.Sequencing;
using Game.Client.View;
using Game.Shared;
using Game.Shared.Messages;

namespace Game.Client.ViewLogic
{
    public class ShipCollidedCollectableAction : IShipCollidedCollectableAction
    {
        private readonly ILogicBridge<Message<MessageType>> logicBridge;
        private readonly InstructionsHandlerBehaviour instructionHandler;

        public ShipCollidedCollectableAction(ILogicBridge<Message<MessageType>> logicBridge,
            InstructionsHandlerBehaviour instructionHandler)
        {
            this.logicBridge = logicBridge;
            this.instructionHandler = instructionHandler;
        }

        public void Invoke(CollectableView collectableView)
        {
            InstructionsSequence sequence = new InstructionsSequence();

            sequence.Append(new DespawnCollectableInstruction(collectableView));

            //logicBridge.Send(new ShipCollidedMessage());

            instructionHandler.EnqueueMainInstruction(sequence);
        }
    }
}
