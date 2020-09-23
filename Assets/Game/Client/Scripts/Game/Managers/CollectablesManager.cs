using System;
using UnityEngine;
using Juce.Utils.Contracts;
using Game.Client.Settings;
using Game.Client.View;
using Game.Shared;
using Game.Shared.Objects;

namespace Game.Client.Managers
{
    public class CollectablesManager
    {
        private readonly CollectablesSettings collectablesSettings;

        public CollectablesManager(CollectablesSettings collectablesSettings)
        {
            Contract.IsNotNull(collectablesSettings);

            this.collectablesSettings = collectablesSettings;
        }

        public void SpawnMapSectionCollectables(MapSection mapSection, MapSectionView mapSectionView)
        {
            //for(int i = 0; i < mapSection.MapCollectables.Count; ++i)
            //{
            //    MapCollectable currMapCollectable = mapSection.MapCollectables[i];

            //    //SpawnCollectableView(mapSectionView, currMapCollectable.UID);
            //}
        }

        //public CollectableView SpawnCollectableView(MapSectionView mapSectionView, string uid)
        //{
        //    Contract.IsNotNull(mapSectionView);

        //    MapSectionCollectable mapSectionCollectable = null;

        //    //for (int i = 0; i < mapSectionView.Collectables.Count; ++i)
        //    //{
        //    //    MapSectionCollectable currMapSectionCollectable = mapSectionView.Collectables[i];

        //    //    if(currMapSectionCollectable.MapCollectableConfig.UID.Equals(uid))
        //    //    {
        //    //        mapSectionCollectable = currMapSectionCollectable;

        //    //        break;
        //    //    }
        //    //}

        //    //Contract.IsNotNull(mapSectionCollectable, $"Tried to find new {nameof(MapSectionCollectable)} " +
        //    //    $"with uid {uid}, but it could not be found");

        //    return SpawnCollectableView(mapSectionCollectable);
        //}

        //public CollectableView SpawnCollectableView(MapSectionCollectable mapSectionCollectable)
        //{
        //    Contract.IsNotNull(mapSectionCollectable);

        //    CollectableView prefabToSpawn = null;

        //    for (int i = 0; i < collectablesSettings.CollectableEntries.Count; ++i)
        //    {
        //        CollectableSettingsEntry currEntry = collectablesSettings.CollectableEntries[i];

        //        if(currEntry.CollectableType == mapSectionCollectable.MapCollectableConfig.CollectableType)
        //        {
        //            prefabToSpawn = currEntry.CollectableView;

        //            break;
        //        }
        //    }

        //    Contract.IsNotNull(prefabToSpawn, $"Tried to spawn new {nameof(CollectableView)} " +
        //        $"but it could not be found");

        //    CollectableView instance = prefabToSpawn.gameObject.InstantiateAndGetComponent<CollectableView>(mapSectionCollectable.gameObject.transform);

        //    Contract.IsNotNull(instance, $"Tried to spawn new {nameof(CollectableView)} " +
        //        $"but prefab did not contain the component");

        //    return instance;
        //}
    }
}
