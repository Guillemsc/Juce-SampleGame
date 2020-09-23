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

namespace Game.Client.ViewModels
{
    public class LoseScreenViewModel : ViewModel
    {
        [Header("Data")]
        [SerializeField] private Button playAgainButton = default;

        [Header("Feedbacks")]
        [SerializeField] private FeedbacksPlayer showFeedback = default;
        [SerializeField] private FeedbacksPlayer hideFeedback = default;

        private ButtonBinding playAgainButtonBinding;

        protected override void Bind()
        {
            playAgainButtonBinding = new ButtonBinding(playAgainButton, OnClickPlayAgainButton);
            playAgainButtonBinding.Bind();
        }

        public override async Task Show()
        {
            await showFeedback.Play();
        }

        public override async Task Hide()
        {
            await hideFeedback.Play();
        }

        private void OnClickPlayAgainButton()
        {
            PlayAgain().ExecuteAsync();
        }

        private async Task PlayAgain()
        {
            LoadingContext loadingContext = ContextsProvider.Instance.GetContext<LoadingContext>();

            await loadingContext.ShowLoadingScreen();

            UIControlService uiControlService = ServicesProvider.Instance.GetService<UIControlService>();
            ContextLoaderService contextLoader = ServicesProvider.Instance.GetService<ContextLoaderService>();

            await contextLoader.GameContextLoader.Unload();
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
