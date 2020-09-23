using System;
using UnityEngine;
using Game.Client.Config;
using Game.Shared.Config;

namespace Game.Client.Settings
{
    [CreateAssetMenu(fileName = "MatchLogicSettings", menuName = "SampleGame/Client/Settings/MatchLogicSettings", order = 1)]
    public class MatchLogicSettings : ScriptableObject
    {
        [Header("Data")]
        [SerializeField] private MapSectionsConfig mapSectionsConfig = default;

        public IMapSectionsConfig MapSectionsConfig => mapSectionsConfig;
    }
}
