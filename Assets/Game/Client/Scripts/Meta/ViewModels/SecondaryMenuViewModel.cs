using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Juce.Feedbacks;
using Juce.Core.UI;
using Juce.Core.Contexts;
using Juce.Core.Services;
using Game.Client.Contexts;
using Game.Client.Services;
using Juce.Core.Service;

namespace Game.Client.Meta.ViewModels
{
    public class SecondaryMenuViewModel : ViewModel
    {
        [Header("Data")]
        [SerializeField] private Button backButton = default;
        [SerializeField] private Button submenuButton = default;
        [SerializeField] private Button secondaryMatchButton = default;

        [Header("Feedbacks")]
        [SerializeField] private FeedbacksPlayer showFeedback = default;
        [SerializeField] private FeedbacksPlayer hideFeedback = default;

        private ButtonBinding backButtonBinding;
        private ButtonBinding submenuButtonBinding;
        private ButtonBinding secondaryMatchButtonBinding;

        protected override void Bind()
        {
            backButtonBinding = new ButtonBinding(backButton, OnClickBackButton);
            backButtonBinding.Bind();

            submenuButtonBinding = new ButtonBinding(submenuButton, OnClickSubmenuButton);
            submenuButtonBinding.Bind();

            secondaryMatchButtonBinding = new ButtonBinding(secondaryMatchButton, OnClickSecondaryMatchButton);
            secondaryMatchButtonBinding.Bind();
        }

        public override async Task Show()
        {
            //await showFeedback.Play();
        }

        public override async Task Hide()
        {
            //await hideFeedback.Play();
        }

        private void OnClickBackButton()
        {
            MetaContext metaContext = ContextsProvider.Instance.GetContext<MetaContext>();
            metaContext.FromSecondaryMenuToMainMenu().ExecuteAsync();
        }

        private void OnClickSubmenuButton()
        {
            MetaContext metaContext = ContextsProvider.Instance.GetContext<MetaContext>();
            metaContext.ShowSubMenu().ExecuteAsync();
        }

        private void OnClickSecondaryMatchButton()
        {
            GoToGameContext().ExecuteAsync();
        }

        private async Task GoToGameContext()
        {
            LoadingContext loadingContext = ContextsProvider.Instance.GetContext<LoadingContext>();

            await loadingContext.ShowLoadingScreen();

            UIControlService uiControlService = ServicesProvider.Instance.GetService<UIControlService>();
            ContextLoaderService contextLoader = ServicesProvider.Instance.GetService<ContextLoaderService>();

            uiControlService.ClearViewModel();

            await contextLoader.MetaContextLoader.Unload();
            await contextLoader.GameContextLoader.Load();

            GameContext gameContext = ContextsProvider.Instance.GetContext<GameContext>();

            while (!gameContext.IsReady)
            {
                await Task.Yield();
            }

            await loadingContext.HideLoadingScreen();
        }
    }
}
