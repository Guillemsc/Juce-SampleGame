using System;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public interface IShipCollidedPointLineAction
    {
        void Invoke(PointLineView pointLineView);
    }
}
