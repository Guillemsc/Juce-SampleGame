using System;
using Juce.Core.Events;
using Game.Client.Events;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public class ShipViewCollisionsInput
    {
        private EventReference shipCollidedEvent;

        public event Action<ObstacleView> OnCollidedObstacle;
        public event Action<CollectableView> OnCollidedCollectable;
        public event Action<PointLineView> OnCollidedPointLine;

        private bool enabled;

        public void Enable()
        {
            if(enabled)
            {
                return;
            }

            enabled = true;

            shipCollidedEvent = EventsProvider.Instance.Subscribe<ShipViewCollidedEvent>((ShipViewCollidedEvent evData) =>
            {
                ObstacleView obstacleView = evData.Collider2DData.Collider2D.GetComponent<ObstacleView>();

                if (obstacleView != null)
                {
                    OnCollidedObstacle?.Invoke(obstacleView);
                    return;
                }

                CollectableView collectableView = evData.Collider2DData.Collider2D.GetComponent<CollectableView>();

                if (collectableView != null)
                {
                    OnCollidedCollectable?.Invoke(collectableView);
                    return;
                }

                PointLineView pointLineView = evData.Collider2DData.Collider2D.GetComponent<PointLineView>();

                if (pointLineView != null)
                {
                    OnCollidedPointLine?.Invoke(pointLineView);
                    return;
                }
            });
        }

        public void Disable()
        {
            if(!enabled)
            {
                return;
            }

            enabled = false;

            EventsProvider.Instance.Unsubscribe(shipCollidedEvent);
            shipCollidedEvent = null;
        }
    }
}
