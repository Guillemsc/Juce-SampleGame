using System;
using UnityEngine;
using Game.Client.ViewModels;

namespace Game.Client.Settings
{
    [System.Serializable]
    public class ViewModelsSettings
    {
        [SerializeField] private DirectionBarViewModel directionBarViewModel = default;
        [SerializeField] private LoseScreenViewModel loseScreenViewModel = default;

        public DirectionBarViewModel DirectionBarViewModel => directionBarViewModel;
        public LoseScreenViewModel LoseScreenViewModel => loseScreenViewModel;
    }
}
