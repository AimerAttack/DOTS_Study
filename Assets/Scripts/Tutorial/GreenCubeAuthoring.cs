using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    struct GreenCubeTag : IComponentData
    {
        
    }
    
    public class GreenCubeAuthoring : MonoBehaviour
    {
        public class Baker : Baker<GreenCubeAuthoring>
        {
            public override void Bake(GreenCubeAuthoring authoring)
            {
                var greenCube = new GreenCubeTag();
                AddComponent(greenCube);
            }
        }
    }
}