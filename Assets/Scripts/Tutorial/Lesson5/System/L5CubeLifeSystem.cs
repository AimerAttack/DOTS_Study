using DefaultNamespace.Lesson5.Job;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using NotImplementedException = System.NotImplementedException;

namespace DefaultNamespace.Lesson5.System
{
    [BurstCompile]
    [UpdateAfter(typeof(L5CubeCreateSystem))]
    public partial struct L5CubeLifeSystem : ISystem
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
            var ecb = new EntityCommandBuffer(Allocator.TempJob);
            var job = new L5LifeUpdateJob()
            {
                deltaTime = SystemAPI.Time.DeltaTime,
                Writer = ecb.AsParallelWriter()
            };
            state.Dependency = job.ScheduleParallel(state.Dependency);
            state.Dependency.Complete();
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}