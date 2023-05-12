using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    struct RedCubeTag : IComponentData
    {
        
    }
    public class RedCubeAuthoring : MonoBehaviour
    {
        public class Baker: Baker<RedCubeAuthoring>
        {
            public override void Bake(RedCubeAuthoring authoring)
            {
                var redCube = new RedCubeTag();
                AddComponent(redCube);
            }
        }
    }
}