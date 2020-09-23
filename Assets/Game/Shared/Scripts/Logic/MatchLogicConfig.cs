using System;
using Game.Shared.Config;

namespace Game.Shared.Logic
{
    public class MatchLogicConfig
    {
        public IMapSectionsConfig MapSectionsConfig { get; }

        public MatchLogicConfig(IMapSectionsConfig mapSectionsConfig)
        {
            MapSectionsConfig = mapSectionsConfig;
        }
    }
}
