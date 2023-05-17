using DefaultNamespace.Lesson7.Authoring;
using DefaultNamespace.Lesson7.Group;
using DefaultNamespace.Lesson7.Job;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using NotImplementedException = System.NotImplementedException;

namespace DefaultNamespace.Lesson7.System
{
    [BurstCompile]
    [UpdateInGroup(typeof(L7Group))]
    public partial struct L7MoveCubeSystem : ISystem
    {
        private EntityQuery query;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<L7CubeGenerator>();

            var queryBuilder = new EntityQueryBuilder(Allocator.Temp).WithAll<L7MoveSpeed,L7RotateSpeedComponentData, LocalTransform>()
                .WithOptions(EntityQueryOptions.IgnoreComponentEnabledState);
            query = state.GetEntityQuery(queryBuilder);
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var job = new L7MoveJob()
            {
                m_RotateSpeedLookup = state.GetComponentLookup<L7MoveSpeed>(),
                deltaTime = SystemAPI.Time.DeltaTime,
                transformLookup = state.GetComponentLookup<LocalTransform>(),
                rotationLookup = state.GetComponentLookup<L7RotateSpeedComponentData>()
            };
            state.Dependency = job.ScheduleParallel(query,state.Dependency);
            state.Dependency.Complete();
        }
    }
}