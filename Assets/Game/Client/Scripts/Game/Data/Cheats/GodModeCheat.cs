using System;
using System.ComponentModel;
using Juce.Core.Logic;
using Game.Shared;
using Game.Shared.Messages;

namespace Game.Client.ViewLogic
{
    public class GodModeCheat
    {
        private readonly ILogicBridge<Message<MessageType>> logicBridge;

        private bool enabled;

        public GodModeCheat(ILogicBridge<Message<MessageType>> logicBridge)
        {
            this.logicBridge = logicBridge;
        }

        [Category("Ship")]
        public bool GodMode 
        {
            get { return enabled; }

            set 
            {
                enabled = value;

                logicBridge.Send(new SetGodModeCheatMessage(enabled));
            } 
        }
    }
}
