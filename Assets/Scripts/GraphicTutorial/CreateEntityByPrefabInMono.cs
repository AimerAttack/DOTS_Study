using System;
using DefaultNamespace.Lesson6.Authoring;
using Unity.Entities;
using UnityEngine;

namespace GraphicTutorial
{
    public class CreateEntityByPrefabInMono : MonoBehaviour
    {
        public GameObject prefab;

        private void Start()
        {
            // var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);        /* 从我们的prefab中创建一个实体对象 */
            // var entityFromPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, settings);        /* 实体管理器 */
            // var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;       
            
            EntityManager _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            EntityQuery colorTablesQ = _entityManager.CreateEntityQuery(new ComponentType[] { typeof(PrefabHolder) });
            colorTablesQ.TryGetSingletonEntity<PrefabHolder>(out Entity colorTablesEntity);

            var comp = _entityManager.GetComponentData<PrefabHolder>(colorTablesEntity);
            Debug.Log(comp.CubePrefab);

            _entityManager.Instantiate(comp.CubePrefab);
            _entityManager.Instantiate(comp.CubePrefab);
        }
    }
}