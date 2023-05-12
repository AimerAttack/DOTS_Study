using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace DefaultNamespace
{
    [BurstCompile]
    public partial struct RedCubeRotateSystem : ISystem
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
            foreach (var (transform,speed,tag) in SystemAPI.Query<RefRW<LocalTransform>,RefRO<RotateSpeed>,RefRO<RedCubeTag>>())
            {
                transform.ValueRW = transform.ValueRW.RotateY(speed.ValueRO.rotateSpeed * deltaTime);
            }
        } 
    }
}