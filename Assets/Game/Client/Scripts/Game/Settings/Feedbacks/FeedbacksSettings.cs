using System;
using UnityEngine;
using Juce.Feedbacks;

namespace Game.Client.Settings
{
    [System.Serializable]
    public class FeedbacksSettings
    {
        [SerializeField] private FeedbacksPlayer shipDestroyedWorldFeedback = default;

        public FeedbacksPlayer ShipDestroyedWorldFeedback => shipDestroyedWorldFeedback;
    }
}
