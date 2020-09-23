using System;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public interface IShipCollidedCollectableAction
    {
        void Invoke(CollectableView collectableView);
    }
}
