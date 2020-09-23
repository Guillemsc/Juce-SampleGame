using System;
using UnityEngine;
using Game.Client.View;
using Game.Shared.Objects;

namespace Game.Client.Settings
{
    [System.Serializable]
    public class CollectableSettingsEntry
    {
        [SerializeField] private CollectableType collectableType = default;
        [SerializeField] private CollectableView collectableView = default;

        public CollectableType CollectableType => collectableType;
        public CollectableView CollectableView => collectableView;
    }
}
