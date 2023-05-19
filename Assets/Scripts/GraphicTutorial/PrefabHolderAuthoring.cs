using Unity.Entities;
using UnityEngine;

namespace GraphicTutorial
{
    struct PrefabHolder : IComponentData
    {
        public Entity CubePrefab;
    }
    public class PrefabHolderAuthoring : MonoBehaviour
    {
        public GameObject CubePrefab;

        public class Baker : Baker<PrefabHolderAuthoring>
        {
            public override void Bake(PrefabHolderAuthoring authoring)
            {
                AddComponent(new PrefabHolder()
                {
                    CubePrefab = GetEntity(authoring.CubePrefab)
                });
            }
        }
    }
}