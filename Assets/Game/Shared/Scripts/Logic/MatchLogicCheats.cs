using System;
using Game.Shared.Messages;

namespace Game.Shared.Logic
{
    public partial class MatchLogic
    {
        private bool GodMode { get; set; }

        private void LinkCheats()
        {
            LogicBridge.OnReceived += (Message<MessageType> message) =>
            {
                switch (message.Type)
                {
                    case MessageType.SetGodModeCheat:
                        {
                            SetGodModeCheatMessage received = (SetGodModeCheatMessage)message;

                            GodMode = received.Enabled;
                        }
                        break;
                }
            };
        }
    }
}
