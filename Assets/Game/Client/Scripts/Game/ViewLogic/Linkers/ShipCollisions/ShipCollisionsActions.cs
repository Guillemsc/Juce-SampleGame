using System;

namespace Game.Client.ViewLogic
{
    public class ShipCollisionsActions
    {
        public IShipCollidedObstacleAction ShipCollidedObstacle { get; }
        public IShipCollidedCollectableAction ShipCollidedCollectable{ get; }
        public IShipCollidedPointLineAction ShipCollidedPointLine { get; }

        public ShipCollisionsActions(
            IShipCollidedObstacleAction shipCollidedObstacle,
            IShipCollidedCollectableAction shipCollidedCollectable,
            IShipCollidedPointLineAction shipCollidedPointLine)
        {
            ShipCollidedObstacle = shipCollidedObstacle;
            ShipCollidedCollectable = shipCollidedCollectable;
            ShipCollidedPointLine = shipCollidedPointLine;
        }
    }
}
