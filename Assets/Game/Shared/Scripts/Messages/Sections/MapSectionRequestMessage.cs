using System;

namespace Game.Shared.Messages
{
    public class MapSectionRequestMessage : Message<MessageType>
    {
        public MapSectionRequestMessage() : base(MessageType.MapSectionRequest)
        {

        }
    }
}
