using System;
using System.Threading.Tasks;
using UnityEngine;
using Juce.Core.Contexts;
using Juce.Core.Services;
using Juce.Core.Service;

namespace Game.Client.Contexts
{
    public class MetaContext : Context
    {
        [SerializeField] private MetaContextReferences references = default;

        private UIControlService uiControlService;

        public MetaContextReferences References => references;

        protected override void InitContext()
        {
            ContextsProvider.Instance.RegisterContext(this);

            uiControlService = ServicesProvider.Instance.GetService<UIControlService>();

            uiControlService.PushViewModel(references.MainMenuViewModel).ExecuteAsync();
        }

        protected override void CleanUpContext()
        {
            ContextsProvider.Instance.UnregisterContext(this);
        }

        public async Task FromMainMenuToSecondaryMenu()
        {
            await uiControlService.PopViewModel();
            uiControlService.PushViewModel(references.SecondaryMenuViewModel).ExecuteAsync();
        }

        public async Task FromSecondaryMenuToMainMenu()
        {
            await uiControlService.PopViewModel();
            uiControlService.PushViewModel(references.MainMenuViewModel).ExecuteAsync();
        }

        public async Task ShowSubMenu()
        {
            uiControlService.PushSubViewModel(references.SubMenuViewModel).ExecuteAsync();
        }
    }
}
