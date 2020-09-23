using System;
using System.Collections.Generic;

namespace Game.Shared.Config
{
    public interface IMapSectionsConfig
    {
        IReadOnlyList<IMapSectionConfig> SectionsConfig { get; }
    }
}
