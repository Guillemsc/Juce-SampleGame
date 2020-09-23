using System;
using Game.Shared.Objects;

namespace Game.Shared.Messages
{
    public class SpawnMapSectionMessage : Message<MessageType>
    {
        public MapSection MapSection { get; }

        public SpawnMapSectionMessage(MapSection mapSection) : base(MessageType.SpawnMapSection)
        {
            MapSection = mapSection;
        }
    }
}
