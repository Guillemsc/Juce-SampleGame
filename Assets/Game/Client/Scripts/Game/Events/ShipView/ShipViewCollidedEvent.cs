using System;
using Juce.Core.Physics;

namespace Game.Client.Events
{
    public class ShipViewCollidedEvent
    {
        public Collider2DData Collider2DData { get; }

        public ShipViewCollidedEvent(Collider2DData collider2DData)
        {
            Collider2DData = collider2DData;
        }
    }
}
