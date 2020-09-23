using System;

namespace Game.Shared.Messages
{
    public class ShipCollidedMessage : Message<MessageType>
    {
        public ShipCollidedMessage() : base(MessageType.ShipCollided)
        {

        }
    }
}
