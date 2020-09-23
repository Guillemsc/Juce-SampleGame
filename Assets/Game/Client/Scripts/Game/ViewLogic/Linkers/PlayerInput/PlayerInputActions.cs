using System;

namespace Game.Client.ViewLogic
{
    public class PlayerInputActions
    {
        public IDirectionTriggerAction DirectionTrigger { get; }

        public PlayerInputActions(
            IDirectionTriggerAction directionTrigger)
        {
            DirectionTrigger = directionTrigger;
        }
    }
}
