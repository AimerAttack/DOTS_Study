using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace.Lesson5.Authoring
{
    struct L5CubeGenerater : IComponentData
    {
        public Entity ArcheType;
        public int MaxCount;
        public float Interval;
        public int CreateNumPerInterval;
    }
    
    public class L5CubeGeneraterAuthoring : MonoBehaviour
    {
        public GameObject ArcheType;
        public int MaxCount;
        public float Interval;
        public int CreateNumPerInterval;
        
        public class Baker : Baker<L5CubeGeneraterAuthoring>
        {
            public override void Bake(L5CubeGeneraterAuthoring authoring)
            {
                AddComponent(new L5CubeGenerater()
                {
                    ArcheType = GetEntity(authoring.ArcheType),
                    MaxCount = authoring.MaxCount,
                    Interval = authoring.Interval,
                    CreateNumPerInterval = authoring.CreateNumPerInterval
                });
            }
        }
    }
}