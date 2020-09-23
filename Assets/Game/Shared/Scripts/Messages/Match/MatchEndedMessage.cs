using System;

namespace Game.Shared.Messages
{
    public class MatchEndedMessage : Message<MessageType>
    {
        public MatchEndedMessage() : base(MessageType.MatchEnded)
        {

        }
    }
}
