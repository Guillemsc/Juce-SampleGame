using System;
using UnityEngine;
using TMPro;

namespace Game.Client.View
{
    public class PointsNumberView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text = default;

        public void SetValue(int set)
        {
            text.text = set.ToString();
        }
    }
}
