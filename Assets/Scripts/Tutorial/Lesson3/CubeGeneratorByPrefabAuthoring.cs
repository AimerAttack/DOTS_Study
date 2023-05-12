using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace.Lesson3
{
    struct CubeGeneratorByPrefab : IComponentData
    {
        public Entity cubeEntityProtoType;
        public int cubeCount;
    }
    
    public class CubeGeneratorByPrefabAuthoring : Singleton<CubeGeneratorByPrefabAuthoring>
    {
        public GameObject cubePrefab;
        [Range(1, 20)] public int cubeCount = 6;

        class CubeBaker : Baker<CubeGeneratorByPrefabAuthoring>
        {
            public override void Bake(CubeGeneratorByPrefabAuthoring authoring)
            {
                AddComponent(new CubeGeneratorByPrefab()
                {
                    cubeEntityProtoType = GetEntity(authoring.cubePrefab),
                    cubeCount = authoring.cubeCount
                });
            }
        }
    }
}