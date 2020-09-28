using System;
using System.Threading.Tasks;
using UnityEngine;
using Juce.Feedbacks;
using Juce.Core.UI;

namespace Game.Client.Meta.ViewModels
{
    public class SubMenuViewModel : ViewModel
    {
        [Header("Feedbacks")]
        [SerializeField] private FeedbacksPlayer showFeedback = default;
        [SerializeField] private FeedbacksPlayer hideFeedback = default;

        //public override async Task Show()
        //{
        //    await showFeedback.Play();
        //}

        //public override async Task Hide()
        //{
        //    await hideFeedback.Play();
        //}
    }
}
