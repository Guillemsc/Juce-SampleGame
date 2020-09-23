using System;
using Game.Shared.Objects;

namespace Game.Client.ViewLogic
{
    public interface ISpawnMapSectionAction
    {
        void Invoke(MapSection mapSection);
    }
}
