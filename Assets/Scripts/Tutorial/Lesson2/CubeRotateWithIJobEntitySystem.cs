using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace DefaultNamespace.Lesson2
{
    partial struct RotateCubeWithJobEntity : IJobEntity
    {
        public float deltaTime;

        void Execute(ref LocalTransform transform, in RotateSpeed speed)
        {
            transform = transform.RotateY(speed.rotateSpeed * deltaTime);
        }
    }
    
    [BurstCompile]
    [UpdateInGroup(typeof(CubeRotateWithIJobEntitySystemGroup))]
    public partial struct CubeRotateWithIJobEntitySystem : ISystem
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
            var job = new RotateCubeWithJobEntity()
            {
                deltaTime = SystemAPI.Time.DeltaTime
            };
            
            job.ScheduleParallel();
        }
    }
}