using System;
using Juce.Utils.Contracts;
using Juce.Core.Tickable;
using Juce.Core.Services;
using Game.Client.Managers;
using Game.Client.Settings;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public class MapSectionsDespawnBehaviour : Juce.Core.ViewLogic.Behaviour, ITickable
    {
        private readonly TickablesService tickableService;
        private readonly MapSectionsSettings mapSectionsSettings;
        private readonly MapSectionsManager mapSectionsManager;

        private bool enabled = false;

        private ShipView shipView;

        public MapSectionsDespawnBehaviour(TickablesService tickableService, MapSectionsSettings mapSectionsSettings,
            MapSectionsManager mapSectionsManager)
        {
            Contract.IsNotNull(tickableService);
            Contract.IsNotNull(mapSectionsSettings);
            Contract.IsNotNull(mapSectionsManager);

            this.tickableService = tickableService;
            this.mapSectionsSettings = mapSectionsSettings;
            this.mapSectionsManager = mapSectionsManager;

            this.shipView = null;
        }

        protected override void OnEnable()
        {
            tickableService.AddTickable(this);
        }

        protected override void OnDisable()
        {
            tickableService.RemoveTickable(this);
        }

        public void Tick()
        {
            DespawnSections();
        }

        public void Start(ShipView shipView)
        {
            if (!enabled)
            {
                enabled = true;
            }

            Contract.IsNotNull(shipView);

            this.shipView = shipView;
        }

        private void DespawnSections()
        {
            if (shipView == null)
            {
                return;
            }

            if (mapSectionsManager.SpawnedMapSectionsView.Count == 0)
            {
                return;
            }

            MapSectionView currSection = mapSectionsManager.SpawnedMapSectionsView[0];

            if (currSection.End.position.y > shipView.transform.position.y - mapSectionsSettings.DespawnOffsetFromShip)
            {
                return;
            }

            mapSectionsManager.DespawnMapSectionView(currSection);
        }
    }
}

