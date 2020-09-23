using System;

namespace Game.Client.ViewLogic
{
    public class RightInputAction : IRightInputAction
    {
        private readonly ShipViewMovementBehaviour shipViewMovementBehaviour;

        public RightInputAction(ShipViewMovementBehaviour shipViewMovementBehaviour)
        {
            this.shipViewMovementBehaviour = shipViewMovementBehaviour;
        }

        public void Invoke()
        {
            
        }
    }
}
