using System;
using System.Threading.Tasks;
using UnityEngine;
using Juce.Core.Services;
using Juce.Core.Contexts;
using Juce.Core.Service;

namespace Game.Client.Contexts
{
    public class LoadingContext : Context
    {
        [SerializeField] private LoadingContextReferences references = default;

        private UIControlService uiControlService;

        public LoadingContextReferences References => references;

        protected override void InitContext()
        {
            ContextsProvider.Instance.RegisterContext(this);

            uiControlService = ServicesProvider.Instance.GetService<UIControlService>();
        }

        protected override void CleanUpContext()
        {
            ContextsProvider.Instance.UnregisterContext(this);
        }

        public async Task ShowLoadingScreen()
        {
            await references.LoadingScreenViewModel.Show();
        }

        public async Task HideLoadingScreen()
        {
            await references.LoadingScreenViewModel.Hide();
        }
    }
}
