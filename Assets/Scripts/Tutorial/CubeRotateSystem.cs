using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DefaultNamespace
{
    public partial struct CubeRotateSystem : ISystem
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
            foreach (var (transform,speed) in SystemAPI.Query<RefRW<LocalTransform>,RefRO<RotateSpeed>>())
            {
                // transform.ValueRW.Value = transform.ValueRW.Value * float4x4.RotateY(speed.ValueRO.rotateSpeed * deltaTime);
                transform.ValueRW = transform.ValueRO.RotateY(speed.ValueRO.rotateSpeed * deltaTime);
            }
        }
    }
}