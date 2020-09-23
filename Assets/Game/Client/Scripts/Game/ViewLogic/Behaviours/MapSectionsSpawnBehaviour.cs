using System;
using System.Collections.Generic;
using Juce.Utils.Contracts;
using Juce.Core.Tickable;
using Juce.Core.Services;
using Juce.Core.Logic;
using Game.Client.Managers;
using Game.Client.View;
using Game.Client.Settings;
using Game.Shared;
using Game.Shared.Messages;
using Game.Shared.Objects;

namespace Game.Client.ViewLogic
{
    public class MapSectionsSpawnBehaviour : Juce.Core.ViewLogic.Behaviour, ITickable
    {
        private readonly ILogicBridge<Message<MessageType>> logicBridge;
        private readonly TickablesService tickableService;
        private readonly MapSectionsSettings mapSectionsSettings;
        private readonly MapSectionsManager mapSectionsManager;
        private readonly CollectablesManager collectablesManager;

        private bool enabled = false;

        private readonly Queue<MapSection> sectionsToSpawn = new Queue<MapSection>();

        private ShipView shipView;
        private float currPosition;
        private bool usedStartingDistance;

        public MapSectionsSpawnBehaviour(ILogicBridge<Message<MessageType>> logicBridge,
            TickablesService tickableService, MapSectionsSettings mapSectionsSettings,
            MapSectionsManager mapSectionsManager, CollectablesManager collectablesManager)
        {
            Contract.IsNotNull(logicBridge);
            Contract.IsNotNull(tickableService);
            Contract.IsNotNull(mapSectionsSettings);
            Contract.IsNotNull(mapSectionsManager);
            Contract.IsNotNull(collectablesManager);

            this.logicBridge = logicBridge;
            this.tickableService = tickableService;
            this.mapSectionsSettings = mapSectionsSettings;
            this.mapSectionsManager = mapSectionsManager;
            this.collectablesManager = collectablesManager;

            this.shipView = null;
        }

        protected override void OnEnable()
        {
            tickableService.AddTickable(this);
        }

        protected override void OnDisable()
        {
            shipView = null;

            tickableService.RemoveTickable(this);
        }

        public void Tick()
        {
            SpawnNewSections();
        }

        public void Start(ShipView shipView)
        {
            if(!enabled)
            {
                enabled = true;
            }

            Contract.IsNotNull(shipView);

            this.shipView = shipView;
            currPosition = shipView.transform.position.y;
            usedStartingDistance = false;
        }

        public void AddNextSectionToSpawn(MapSection mapSection)
        {
            sectionsToSpawn.Enqueue(mapSection);
        }

        private void SpawnNewSections()
        {
            if(shipView == null)
            {
                return;
            }

            float checkingPosition = currPosition;

            if(!usedStartingDistance)
            {
                checkingPosition += mapSectionsSettings.StartingDistance;
            }
            else
            {
                checkingPosition += mapSectionsSettings.DistanceBetweenSections;
            }

            if(checkingPosition > shipView.transform.position.y + mapSectionsSettings.SpawnOffsetFromShip)
            {
                return;
            }

            usedStartingDistance = true;

            if(sectionsToSpawn.Count == 0)
            {
                return;
            }

            MapSection mapSection =  sectionsToSpawn.Dequeue();

            MapSectionView mapSectionView = mapSectionsManager.SpawnMapSectionView(mapSection);

            collectablesManager.SpawnMapSectionCollectables(mapSection, mapSectionView);

            float sectionLength = mapSectionView.End.position.y - mapSectionView.Start.position.y;
            float spawnPosition = (sectionLength * 0.5f) + checkingPosition;

            mapSectionView.transform.SetPositionY(spawnPosition);

            currPosition = mapSectionView.End.position.y;

            SpawnNewSections();

            logicBridge.Send(new MapSectionRequestMessage());
        }
    }
}
