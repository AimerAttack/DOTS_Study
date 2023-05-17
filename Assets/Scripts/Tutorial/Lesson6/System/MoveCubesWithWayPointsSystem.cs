using DefaultNamespace.Lesson3;
using DefaultNamespace.Lesson6.Authoring;
using DefaultNamespace.Lesson6.Group;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace DefaultNamespace.Lesson6.System
{
    [BurstCompile]
    [UpdateInGroup(typeof(Lesson6Group))]
    public partial struct MoveCubesWithWayPointsSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            Debug.Log("MoveCubesWithWayPointsSystem OnCreate");
            state.RequireForUpdate<WayPoint>();
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            Debug.Log("MoveCubesWithWayPointsSystem OnUpdate");
            var path = SystemAPI.GetSingletonBuffer<WayPoint>();
            var deltaTime = SystemAPI.Time.DeltaTime;
            if (!path.IsEmpty)
            {
                foreach (var (transform,nextIndex,speed) in SystemAPI.Query<RefRW<LocalTransform>,RefRW<NextPathIndex>,
                         RefRO<RotateAndMoveSpeed>>())
                {
                    var direction = path[(int)nextIndex.ValueRO.nextIndex].point - transform.ValueRO.Position;
                    transform.ValueRW.Position = transform.ValueRO.Position + math.normalize(direction) * speed.ValueRO.moveSpeed * deltaTime;
                    transform.ValueRW = transform.ValueRO.RotateY(speed.ValueRO.rotateSpeed * deltaTime);
                    if (math.distance(path[(int)nextIndex.ValueRO.nextIndex].point, transform.ValueRO.Position) <= 0.02f)
                    {
                        nextIndex.ValueRW.nextIndex = (uint)((nextIndex.ValueRO.nextIndex + 1) % path.Length);
                    }
                }
            }
        }
    }
}