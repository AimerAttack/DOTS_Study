using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace DefaultNamespace
{
    [BurstCompile]
    [UpdateInGroup(typeof(CubeRotateSystemGroup))]
    public partial struct GreenCubeRotateSystem : ISystem
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
            foreach (var (transform,speed,tag) in SystemAPI.Query<RefRW<LocalTransform>,RefRO<RotateSpeed>,RefRO<GreenCubeTag>>())
            {
                transform.ValueRW = transform.ValueRW.RotateY(speed.ValueRO.rotateSpeed * deltaTime);
            }
        }
    }
}