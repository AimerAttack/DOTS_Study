using DefaultNamespace.Lesson7.Authoring;
using DefaultNamespace.Lesson7.Group;
using DefaultNamespace.Lesson7.Job;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using NotImplementedException = System.NotImplementedException;

namespace DefaultNamespace.Lesson7.System
{
    [BurstCompile]
    [UpdateInGroup(typeof(L7Group))]
    public partial struct L7CreateCubeSystem : ISystem
    {
        private float Time;
        private Random random;
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<L7CubeGenerator>();
            random = new Random(1);
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var generator = SystemAPI.GetSingleton<L7CubeGenerator>();
            if (Time >= generator.Interval)
            {
                Time -= generator.Interval;
                CreateCube(ref state,generator);
            }

            Time += SystemAPI.Time.DeltaTime;
        }
        
        void CreateCube(ref SystemState state,L7CubeGenerator generator)
        {
            var ecb = new EntityCommandBuffer(Allocator.TempJob);
            var cubes = CollectionHelper.CreateNativeArray<Entity>(generator.PerTickCount, Allocator.TempJob);
            var job = new L7CreateCubeJob()
            {
                ArcheType = generator.ArcheType,
                Cubes = cubes,
                Writer = ecb.AsParallelWriter()
            };
            state.Dependency = job.ScheduleParallel(cubes.Length,1,state.Dependency);
            state.Dependency.Complete();
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
            cubes.Dispose();

            var positionJob = new L7RandomPositionJob()
            {
                Speed = SystemAPI.GetSingleton<L7CubeGenerator>().MoveSpeed,
                random = random
            };
            state.Dependency = positionJob.ScheduleParallel(state.Dependency);
            state.Dependency.Complete();
        }
    }
}