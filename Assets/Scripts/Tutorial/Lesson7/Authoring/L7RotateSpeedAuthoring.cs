using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace.Lesson7.Authoring
{
    public class L7RotateSpeedAuthoring : MonoBehaviour
    {
        public float Speed;

        public class L7RotateSpeedAuthoringBaker : Baker<L7RotateSpeedAuthoring>
        {
            public override void Bake(L7RotateSpeedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new L7RotateSpeedComponentData()
                {
                    Speed = authoring.Speed
                });
            }
        }
    }

    public struct L7RotateSpeedComponentData : IComponentData,IEnableableComponent
    {
        public float Speed;
    }
}