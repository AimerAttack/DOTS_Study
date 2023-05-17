using Unity.Entities;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace DefaultNamespace.Lesson7.Authoring
{
    public struct L7MoveSpeed : IComponentData,IEnableableComponent
    {
        public float speed;
    }
    
    public class L7MoveSpeedAuthoring : MonoBehaviour
    {
        public class Baker : Baker<L7MoveSpeedAuthoring>
        {
            public override void Bake(L7MoveSpeedAuthoring authoring)
            {
                AddComponent(new L7MoveSpeed());
            }
        }
    }
}