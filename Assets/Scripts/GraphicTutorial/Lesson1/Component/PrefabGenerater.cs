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
        public Mesh Mesh1;
        public Mesh Mesh2;
        public Material Mat1;
        public Material Mat2;

        public class Baker : Baker<PrefabGenerater>
        {
            public override void Bake(PrefabGenerater authoring)
            {
                AddComponent(new PrefabGeneraterData()
                {
                    prefab = GetEntity(authoring.prefab),
                });
            }
        }
    }
}