using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Client.View;

namespace Game.Client.Settings
{
    [CreateAssetMenu(fileName = "CollectablesSettings", menuName = "SampleGame/Client/Settings/CollectablesSettings", order = 1)]
    public class CollectablesSettings : ScriptableObject
    {
        [Header("Data")]
        [SerializeField] private List<CollectableSettingsEntry> collectableEntries = default;

        public IReadOnlyList<CollectableSettingsEntry> CollectableEntries => collectableEntries;
    }
}
