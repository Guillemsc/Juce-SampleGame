using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Juce.Feedbacks;
using Juce.Core.Contexts;
using Juce.Core.UI;
using Game.Client.Contexts;

namespace Game.Client.Meta.ViewModels
{
    public class MainMenuViewModel : ViewModel
    {
        [Header("Data")]
        [SerializeField] private Button mainMenuButton = default;

        [Header("Feedbacks")]
        [SerializeField] private FeedbacksPlayer showFeedback = default;
        [SerializeField] private FeedbacksPlayer hideFeedback = default;

        private ButtonBinding mainMenuButtonBinding;

        protected override void Bind()
        {
            mainMenuButtonBinding = new ButtonBinding(mainMenuButton, OnClickMainMenuButton);
            mainMenuButtonBinding.Bind();
        }

        public override async Task Show()
        {
            await showFeedback.Play();
        }

        public override async Task Hide()
        {
            await hideFeedback.Play();
        }

        private void OnClickMainMenuButton()
        {
            MetaContext metaContext = ContextsProvider.Instance.GetContext<MetaContext>();
            metaContext.FromMainMenuToSecondaryMenu().ExecuteAsync();
        }
    }
}
