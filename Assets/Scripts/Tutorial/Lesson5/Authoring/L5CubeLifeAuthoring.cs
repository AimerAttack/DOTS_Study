using Unity.Entities;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace DefaultNamespace.Lesson5.Authoring
{
    public struct L5CubeLife : IComponentData
    {
        public float life;
    }
    
    public class L5CubeLifeAuthoring : MonoBehaviour
    {
        public int life;

        public class Baker : Baker<L5CubeLifeAuthoring>
        {
            public override void Bake(L5CubeLifeAuthoring authoring)
            {
                AddComponent(new L5CubeLife()
                {
                    life = authoring.life
                });
            }
        }
    }
}