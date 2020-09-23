using System;

namespace Game.Shared
{
    public class ShipDestroyedMessage : Message<MessageType>
    {
        public ShipDestroyedMessage() : base(MessageType.ShipDestroyed)
        {

        }
    }
}
