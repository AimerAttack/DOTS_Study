using Unity.Burst;
using Unity.Entities;

namespace DefaultNamespace.Lesson3
{
    [BurstCompile]
    public partial struct CubeRotationAndMoveSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            var elapsedTime = SystemAPI.Time.ElapsedTime;

            foreach (var aspect in SystemAPI.Query<RotateAndMoveAspect>())
            {
                aspect.Rotate(deltaTime);
            }
        }
    }
}