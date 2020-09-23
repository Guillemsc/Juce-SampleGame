using System;
using UnityEngine;
using Game.Client.Loading.ViewModels;

namespace Game.Client.Contexts
{
    [System.Serializable]
    public class LoadingContextReferences
    {
        [SerializeField] private LoadingScreenViewModel loadingScreenViewModel = default;

        public LoadingScreenViewModel LoadingScreenViewModel => loadingScreenViewModel;
    }
}
