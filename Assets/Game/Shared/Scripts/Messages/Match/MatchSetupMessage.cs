using System;

namespace Game.Shared
{
    public class MatchSetupMessage : Message<MessageType>
    {
        public MatchSetupMessage() : base(MessageType.MatchSetup)
        {

        }
    }
}
