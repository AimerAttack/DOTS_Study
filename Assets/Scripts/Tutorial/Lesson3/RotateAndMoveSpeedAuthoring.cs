using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace.Lesson3
{
    public struct RotateAndMoveSpeed : IComponentData
    {
        public float rotateSpeed;
        public float moveSpeed;
    }
    
    public class RotateAndMoveSpeedAuthoring : MonoBehaviour
    {
        [Range(0, 360)] public float rotateSpeed = 360;
        [Range(0, 10)] public float moveSpeed = 1;

        public class Baker : Baker<RotateAndMoveSpeedAuthoring>
        {
            public override void Bake(RotateAndMoveSpeedAuthoring authoring)
            {
                var data = new RotateAndMoveSpeed()
                {
                    rotateSpeed = authoring.rotateSpeed,
                    moveSpeed = authoring.moveSpeed
                };
                AddComponent(data);
            }
        }
    }
}