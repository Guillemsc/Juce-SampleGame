using System;
using Juce.Feedbacks;
using Juce.Core.Logic;
using Game.Shared;
using Game.Shared.Messages;

namespace Game.Client.ViewLogic
{
    public class ShipCollidedObstacleAction : IShipCollidedObstacleAction
    {
        private readonly ILogicBridge<Message<MessageType>> logicBridge;

        public ShipCollidedObstacleAction(
            ILogicBridge<Message<MessageType>> logicBridge)
        {
            this.logicBridge = logicBridge;
        }

        public void Invoke()
        {
            logicBridge.Send(new ShipCollidedMessage());
        }
    }
}
