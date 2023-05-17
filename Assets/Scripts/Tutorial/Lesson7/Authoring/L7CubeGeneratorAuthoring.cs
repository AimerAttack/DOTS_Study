using Unity.Entities;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace DefaultNamespace.Lesson7.Authoring
{
    struct L7CubeGenerator : IComponentData
    {
        public int PerTickCount;
        public float Interval;
        public Entity ArcheType;
        public float MoveSpeed;
    }
    public class L7CubeGeneratorAuthoring : MonoBehaviour
    {
        public int PerTickCount = 10;
        public float Interval = 1;
        public float MoveSpeed;
        public GameObject Prefab;

        public class Baker : Baker<L7CubeGeneratorAuthoring>
        {
            public override void Bake(L7CubeGeneratorAuthoring authoring)
            {
                AddComponent(new L7CubeGenerator()
                {
                    PerTickCount = authoring.PerTickCount,
                    Interval = authoring.Interval,
                    MoveSpeed = authoring.MoveSpeed,
                    ArcheType = GetEntity(authoring.Prefab)
                });
            }
        }
    }
}