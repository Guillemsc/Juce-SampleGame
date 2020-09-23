using System;
using UnityEngine;
using UnityEngine.UI;
using Juce.Utils.Contracts;
using Juce.Core.UI;
using Juce.Core.Time;
using Game.Client.Settings;

namespace Game.Client.ViewModels
{
    public class DirectionBarViewModel : ViewModel
    {
        [SerializeField] private GameObject marker = default;
        [SerializeField] private GameObject leftPoint = default;
        [SerializeField] private GameObject rightPoint = default;
        [SerializeField] private Image leftFillImage = default;
        [SerializeField] private Image rightFillImage = default;

        private ITimer timer;
        private DirectionBarSettings directionBarSettings;

        public bool CanMove { get; set; }
        public float FillValue { get; private set; }

        private void Update()
        {
            UpdateFill();
        }

        protected override void Bind()
        {
            Contract.IsNotNull(marker);
            Contract.IsNotNull(leftPoint);
            Contract.IsNotNull(rightPoint);
            Contract.IsNotNull(leftFillImage);
            Contract.IsNotNull(rightFillImage);
        }

        public void Construct(ITimer timer, DirectionBarSettings directionBarSettings)
        {
            Contract.IsNotNull(timer);
            Contract.IsNotNull(directionBarSettings);

            this.timer = timer;
            this.directionBarSettings = directionBarSettings;

            timer.Start();
        }

        private void UpdateFill()
        {
            UpdateFillValue();

            SetFillImagesValue();
            SetMarkerValue();
        }

        private void UpdateFillValue()
        {
            if(!CanMove)
            {
                return;
            }

            Contract.IsNotNull(timer);

            float totalSeconds = (float)timer.Time.TotalSeconds  * directionBarSettings.DefaultSpeed;

            FillValue = Mathf.Sin(totalSeconds);
        }

        private void SetFillImagesValue()
        {
            if (FillValue == 0)
            {
                leftFillImage.fillAmount = 0.0f;
                rightFillImage.fillAmount = 0.0f;
            }
            if (FillValue < 0)
            {
                rightFillImage.fillAmount = 0.0f;
                leftFillImage.fillAmount = Mathf.Abs(FillValue);
            }
            else
            {
                leftFillImage.fillAmount = 0.0f;
                rightFillImage.fillAmount = Mathf.Abs(FillValue);
            }
        }

        private void SetMarkerValue()
        {
            float halfPointsDistance = (rightPoint.transform.position.x - leftPoint.transform.position.x) * 0.5f;
            float pointsCenter = leftPoint.transform.position.x + halfPointsDistance;

            Vector3 newPos = marker.transform.position;
            newPos.x = pointsCenter + (halfPointsDistance * FillValue);

            marker.transform.position = newPos;
        }
    }
}
