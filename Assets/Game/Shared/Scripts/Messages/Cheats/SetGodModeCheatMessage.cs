using System;

namespace Game.Shared.Messages
{
    public class SetGodModeCheatMessage  : Message<MessageType>
    {
        public bool Enabled { get; }

        public SetGodModeCheatMessage(bool enabled) : base(MessageType.SetGodModeCheat)
        {
            Enabled = enabled;
        }
    }
}
