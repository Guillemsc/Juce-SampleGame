using System;
using Juce.Core.Logic;
using Game.Client.View;
using Game.Shared;
using Game.Shared.Messages;

namespace Game.Client.ViewLogic
{
    public class ShipCollidedPointLineAction : IShipCollidedPointLineAction
    {
        private readonly ILogicBridge<Message<MessageType>> logicBridge;

        public ShipCollidedPointLineAction(ILogicBridge<Message<MessageType>> logicBridge)
        {
            this.logicBridge = logicBridge;
        }

        public void Invoke(PointLineView pointLineView)
        {
            pointLineView.PlayCrossed();

            //logicBridge.Send(new ShipCollidedMessage());
        }
    }
}
