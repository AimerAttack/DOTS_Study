using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace.Lesson6.Authoring
{
    struct NextPathIndex : IComponentData
    {
        public uint nextIndex;
    }
    
    public class NextPathIndexAuthoring : MonoBehaviour
    {
        [HideInInspector]public uint nextIndex;

        public class Baker : Baker<NextPathIndexAuthoring>
        {
            public override void Bake(NextPathIndexAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity,new NextPathIndex {nextIndex = authoring.nextIndex});
            }
        }
    }
}