using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    struct BlueCubeTag : IComponentData
    {
    }
    
    public class BlueCubeAuthoring : MonoBehaviour
    {
        public class Baker : Baker<BlueCubeAuthoring>
        {
            public override void Bake(BlueCubeAuthoring authoring)
            {
                var blueCube = new BlueCubeTag();
                AddComponent(blueCube);
            }
        }
    }
}