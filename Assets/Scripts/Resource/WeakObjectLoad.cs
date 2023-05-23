using System;
using Unity.Entities;
using Unity.Entities.Content;
using UnityEngine;

namespace Resource
{
    struct WeakObjectData : IComponentData
    {
        public WeakObjectReference<GameObject> prefab;
    }
    
    public class WeakObjectLoad : MonoBehaviour
    {
        public WeakObjectReference<GameObject> prefab;

        public class Baker : Baker<WeakObjectLoad>
        {
            public override void Bake(WeakObjectLoad authoring)
            {
                AddComponent(new WeakObjectData()
                {
                    prefab = authoring.prefab
                });
            }
        }
    }
}