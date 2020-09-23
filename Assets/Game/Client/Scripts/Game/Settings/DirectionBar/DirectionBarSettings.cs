using System;
using UnityEngine;

namespace Game.Client.Settings
{
    [CreateAssetMenu(fileName = "DirectionBarSettings", menuName = "SampleGame/Client/Settings/DirectionBarSettings", order = 1)]
    public class DirectionBarSettings : ScriptableObject
    {
        [SerializeField] private float defaultSpeed = default;

        public float DefaultSpeed => defaultSpeed;
    }
}
