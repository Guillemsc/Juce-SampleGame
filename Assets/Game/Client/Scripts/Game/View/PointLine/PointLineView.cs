using System;
using UnityEngine;
using Juce.Feedbacks;

namespace Game.Client.View
{
    public class PointLineView : MonoBehaviour
    {
        [SerializeField] private FeedbacksPlayer crossedFeedback = default;

        public void PlayCrossed()
        {
            //crossedFeedback.Play().ExecuteAsync();
        }
    }
}
