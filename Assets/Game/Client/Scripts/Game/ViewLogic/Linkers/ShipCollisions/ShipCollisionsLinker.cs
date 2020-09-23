using System;
using Juce.Core.Logic;
using Juce.Core.Physics;
using Juce.Core.ViewLogic;
using Game.Client.View;
using Game.Shared;

namespace Game.Client.ViewLogic
{
    public class ShipCollisionsLinker : ILinker
    {
        private readonly ShipCollisionsActions shipCollisionsActions;
        private readonly ShipViewCollisionsInput shipViewCollisionsInput;
        private readonly BoolData shipCollidedData;

        public ShipCollisionsLinker(ShipCollisionsActions shipCollisionsActions, ShipViewCollisionsInput shipViewCollisionsInput,
            BoolData shipCollidedData)
        {
            this.shipCollisionsActions = shipCollisionsActions;
            this.shipViewCollisionsInput = shipViewCollisionsInput;
            this.shipCollidedData = shipCollidedData;

            Link();
        }

        public void Link()
        {
            shipViewCollisionsInput.Enable();

            shipViewCollisionsInput.OnCollidedObstacle += (ObstacleView obstacleView) =>
            {
                shipCollisionsActions.ShipCollidedObstacle.Invoke();
            };

            shipViewCollisionsInput.OnCollidedCollectable += (CollectableView collectableView) =>
            {
                shipCollisionsActions.ShipCollidedCollectable.Invoke(collectableView);
            };

            shipViewCollisionsInput.OnCollidedPointLine += (PointLineView pointLineView) =>
            {
                shipCollisionsActions.ShipCollidedPointLine.Invoke(pointLineView);
            };
        }

        public void CleanUp()
        {
            shipViewCollisionsInput.Disable();
        }
    }
}
