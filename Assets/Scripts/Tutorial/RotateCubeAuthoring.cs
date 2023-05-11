using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    struct RotateSpeed : IComponentData
    {
        public float rotateSpeed;
    }
    public class RotateCubeAuthoring : MonoBehaviour
    {
        [Range(0, 360)] public float rotateSpeed = 360;

        public class Baker : Baker<RotateCubeAuthoring>
        {
            public override void Bake(RotateCubeAuthoring authoring)
            {
                var data = new RotateSpeed()
                {
                    rotateSpeed = math.radians(authoring.rotateSpeed)
                };
                AddComponent(data);
            }
        }
    }
}