using System;
using System.Threading.Tasks;
using Juce.Feedbacks;
using Juce.Core.UI;
using UnityEngine;

namespace Game.Client.Loading.ViewModels
{
    public class LoadingScreenViewModel : ViewModel
    {
        [Header("Feedbacks")]
        [SerializeField] private FeedbacksPlayer showFeedback = default;
        [SerializeField] private FeedbacksPlayer hideFeedback = default;

        public override async Task Show()
        {
            await showFeedback.Play();
        }

        public override async Task Hide()
        {
            await hideFeedback.Play();
        }
    }
}
