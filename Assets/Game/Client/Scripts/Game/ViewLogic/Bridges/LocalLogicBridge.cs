using System;
using Juce.Utils.Contracts;
using Juce.Core.Logic;
using Game.Shared;

namespace Game.Client.ViewLogic
{
    public class LocalLogicBridge : LogicBridge<Message<MessageType>>
    {
        private readonly LogicBridge<Message<MessageType>> connectedBridge;

        public LocalLogicBridge(LogicBridge<Message<MessageType>> connectedBridge)
        {
            Contract.IsNotNull(connectedBridge);

            this.connectedBridge = connectedBridge;

            connectedBridge.OnSent += (Message<MessageType> obj) => 
            {
                Receive(obj);
            };

            this.OnSent += (Message<MessageType> obj) =>
            {
                connectedBridge.Receive(obj);
            };
        }
    }
}
