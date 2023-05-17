using DefaultNamespace.Lesson5.Aspect;
using DefaultNamespace.Lesson5.Authoring;
using DefaultNamespace.Lesson5.Group;
using DefaultNamespace.Lesson5.Job;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace DefaultNamespace.Lesson5.System
{
    [BurstCompile]
    [UpdateInGroup(typeof(L5Group))]
    public partial struct L5CubeCreateSystem : ISystem
    {
        private int totalCount;
        private float timer;
        
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<L5CubeGenerater>();
            timer = 0;
            totalCount = 0;
        }

        public void OnDestroy(ref SystemState state)
        {
            
        }

        public void OnUpdate(ref SystemState state)
        {
            var generator = SystemAPI.GetSingleton<L5CubeGenerater>();
            if (totalCount > generator.MaxCount)
            {
                state.Enabled = false;
                return;
            }
            if (timer > generator.Interval)
            {
                timer -= generator.Interval;
                RunCreateCubeJob(ref state,generator);
                state.Enabled = false;
            }

            timer += SystemAPI.Time.DeltaTime;
        }

        void RunCreateCubeJob(ref SystemState state,L5CubeGenerater generater)
        {
            //创建ecb
            var ecb = new EntityCommandBuffer(Allocator.TempJob);
            var cubes = CollectionHelper.CreateNativeArray<Entity>(generater.CreateNumPerInterval, Allocator.TempJob);
            //并行执行
            var job = new L5CreateCubeJob()
            {
                ArcheType = generater.ArcheType,
                Cubes = cubes,
                Writer = ecb.AsParallelWriter()
            };
            var jobLife = new L5LifeJob();
            state.Dependency = job.ScheduleParallel(cubes.Length, 1, state.Dependency);
            state.Dependency.Complete();
            //这里要先将ecb进行playback，否则后续的jobLife检测不到已经创建的entity，无法进行生命周期的初始化
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
            
            state.Dependency = jobLife.ScheduleParallel(state.Dependency);
            state.Dependency.Complete();
            Debug.Log("systemlog");
            
            totalCount += generater.CreateNumPerInterval;
            cubes.Dispose();
        }
    }
}