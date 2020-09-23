using System;

namespace Game.Client.ViewLogic
{
    public class LeftInputAction : ILeftInputAction
    {
        private readonly ShipViewMovementBehaviour shipViewMovementBehaviour;

        public LeftInputAction(ShipViewMovementBehaviour shipViewMovementBehaviour)
        {
            this.shipViewMovementBehaviour = shipViewMovementBehaviour;
        }

        public void Invoke()
        {
          
        }
    }
}
