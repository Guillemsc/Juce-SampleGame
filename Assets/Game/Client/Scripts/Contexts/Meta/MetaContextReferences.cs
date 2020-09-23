using System;
using UnityEngine;
using Game.Client.Meta.ViewModels;

namespace Game.Client.Contexts
{
    [System.Serializable]
    public class MetaContextReferences
    {
        [SerializeField] private MainMenuViewModel mainMenuViewModel = default;
        [SerializeField] private SecondaryMenuViewModel secondaryMenuViewModel = default;
        [SerializeField] private SubMenuViewModel submenuViewModel = default;

        public MainMenuViewModel MainMenuViewModel => mainMenuViewModel;
        public SecondaryMenuViewModel SecondaryMenuViewModel => secondaryMenuViewModel;
        public SubMenuViewModel SubMenuViewModel => submenuViewModel;
    }
}
