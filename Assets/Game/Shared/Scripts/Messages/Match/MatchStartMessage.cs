using System;

namespace Game.Shared
{
    public class MatchStartMessage : Message<MessageType>
    {
        public MatchStartMessage() : base(MessageType.MatchStart)
        {

        }
    }
}
