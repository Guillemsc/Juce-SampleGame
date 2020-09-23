using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Shared.Config;

namespace Game.Client.Config
{
    [CreateAssetMenu(fileName = "MapSectionsConfig", menuName = "SampleGame/Client/Settings/MapSectionsConfig", order = 1)]
    public class MapSectionsConfig : ScriptableObject, IMapSectionsConfig
    {
        [SerializeField] private List<MapSectionConfig> sectionsConfig = default;

        public IReadOnlyList<IMapSectionConfig> SectionsConfig => sectionsConfig;
    }
}
