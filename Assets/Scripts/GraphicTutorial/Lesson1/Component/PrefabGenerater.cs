using Unity.Entities;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace GraphicTutorial.Lesson1
{
    struct PrefabGeneraterData : IComponentData
    {
        public Entity prefab;
    }
    
    public class PrefabGenerater : MonoBehaviour
    {
        public GameObject prefab;

        public class Baker : Baker<PrefabGenerater>
        {
            public override void Bake(PrefabGenerater authoring)
            {
                AddComponent(new PrefabGeneraterData()
                {
                    prefab = GetEntity(authoring.prefab)
                });
            }
        }
    }
}