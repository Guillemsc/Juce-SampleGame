using System;
using UnityEngine;
using Juce.Core.Animation2D;

namespace Game.Client.Settings
{
    [CreateAssetMenu(fileName = "ShipViewSettings", menuName = "SampleGame/Client/Settings/ShipViewSettings", order = 1)]
    public class ShipViewSettings : ScriptableObject
    {
        [SerializeField] private GameObject shipViewPrefab = default;

        public GameObject ShipViewPrefab => shipViewPrefab;
    }
}
