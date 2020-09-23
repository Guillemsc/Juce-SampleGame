using System;
using System.Collections.Generic;
using UnityEngine;
using Juce.Utils.Contracts;
using Game.Client.Settings;
using Game.Client.View;
using Game.Shared.Objects;

namespace Game.Client.Managers
{
    public class MapSectionsManager
    {
        private readonly WorldSettings worldSettings;
        private readonly MapSectionsSettings mapSectionsSettings;

        private readonly List<MapSectionView> spawnedMapSectionsView = new List<MapSectionView>();

        public IReadOnlyList<MapSectionView> SpawnedMapSectionsView => spawnedMapSectionsView;

        public MapSectionsManager(WorldSettings worldSettings, MapSectionsSettings mapSectionsSettings)
        {
            Contract.IsNotNull(worldSettings);
            Contract.IsNotNull(mapSectionsSettings);

            this.worldSettings = worldSettings;
            this.mapSectionsSettings = mapSectionsSettings;
        }

        public MapSectionView SpawnRandomMapSectionView()
        {
            Contract.IsNotZero(mapSectionsSettings.MapSectionsPrefabs.Count, $"Tried to spawn new {nameof(MapSectionView)} " +
                $"but there are no avaliable sections to spawn");

            MapSectionView toSpawn = mapSectionsSettings.MapSectionsPrefabs
                [UnityEngine.Random.Range(0, mapSectionsSettings.MapSectionsPrefabs.Count)];

            MapSectionView instance = toSpawn.gameObject.InstantiateAndGetComponent<MapSectionView>(worldSettings.WorldGameObject.transform);

            Contract.IsNotNull(instance, $"Tried to spawn new {nameof(MapSectionView)} " +
                $"but prefab did not contain the component");

            spawnedMapSectionsView.Add(instance);

            return instance;
        }

        public MapSectionView SpawnMapSectionView(MapSection mapSection)
        {
            MapSectionView prefabToSpawn = null;

            for (int i = 0; i < mapSectionsSettings.MapSectionsPrefabs.Count; ++i)
            {
                MapSectionView currMapSection = mapSectionsSettings.MapSectionsPrefabs[i];

                if (currMapSection.MapSectionConfig.SectionID.Equals(mapSection.SectionID))
                {
                    prefabToSpawn = currMapSection;
                    break;
                }
            }

            Contract.IsNotNull(prefabToSpawn, $"Tried to spawn new {nameof(MapSectionView)} " +
                $"with id {mapSection.SectionID}, but it could not be found");

            MapSectionView instance = prefabToSpawn.gameObject.InstantiateAndGetComponent<MapSectionView>(worldSettings.WorldGameObject.transform);

            Contract.IsNotNull(instance, $"Tried to spawn new {nameof(MapSectionView)} " +
                $"but prefab did not contain the component");

            spawnedMapSectionsView.Add(instance);

            return instance;
        }

        public void DespawnMapSectionView(MapSectionView mapSection)
        {
            Contract.IsNotNull(mapSection, $"Tried to despawn {nameof(MapSectionView)} " +
                $"but it was null");

            bool contains = spawnedMapSectionsView.Remove(mapSection);

            Contract.IsTrue(contains, $"Tried to despawn {nameof(MapSectionView)} " +
                $"but was not added on the first place");

            mapSection.gameObject.Destroy();
        }
    }
}
