using System;
using UnityEngine;
using Game.Client.Settings;
using Game.Shared.Logic;

namespace Game.Client.Contexts
{
    [System.Serializable]
    public class GameContextReferences 
    {
        [SerializeField] private MatchLogicSettings matchLogicSettings = default;
        [SerializeField] private ViewModelsSettings viewModelsSettings = default;
        [SerializeField] private WorldSettings worldSettings = default;
        [SerializeField] private CamerasSettings camerasSettings = default;
        [SerializeField] private WorldSpaceUISettings worldSpaceUISettings = default;
        [SerializeField] private FeedbacksSettings feedbacksSettings = default;
        [SerializeField] private ShipViewSettings shipViewSettings = default;
        [SerializeField] private ShipViewMovementSettings shipViewMovementSettings = default;
        [SerializeField] private DirectionBarSettings directionBarSettings = default;
        [SerializeField] private MapSectionsSettings mapSectionsSettings = default;
        [SerializeField] private CollectablesSettings collectablesSettings = default;
        [SerializeField] private PointLineViewSettings pointLineViewSettings = default;
        [SerializeField] private PointsNumberViewSettings pointsNumberViewSettings = default;
        [SerializeField] private CameraCollidersSettings cameraCollidersSettings = default;

        public MatchLogicSettings MatchLogicSettings => matchLogicSettings;
        public ViewModelsSettings ViewModelsSettings => viewModelsSettings;
        public WorldSettings WorldSettings => worldSettings;
        public CamerasSettings CamerasSettings => camerasSettings;
        public WorldSpaceUISettings WorldSpaceUISettings => worldSpaceUISettings;
        public FeedbacksSettings FeedbacksSettings => feedbacksSettings;
        public ShipViewSettings ShipViewSettings => shipViewSettings;
        public ShipViewMovementSettings ShipViewMovementSettings => shipViewMovementSettings;
        public DirectionBarSettings DirectionBarSettings => directionBarSettings;
        public MapSectionsSettings MapSectionsSettings => mapSectionsSettings;
        public CollectablesSettings CollectablesSettings => collectablesSettings;
        public PointLineViewSettings PointLineViewSettings => pointLineViewSettings;
        public PointsNumberViewSettings PointsNumberViewSettings => pointsNumberViewSettings;
        public CameraCollidersSettings CameraCollidersSettings => cameraCollidersSettings;
    }
}
