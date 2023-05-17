using DefaultNamespace.Lesson7.Authoring;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DefaultNamespace.Lesson7.Job
{
    [BurstCompile]
    public partial struct  L7RandomPositionJob : IJobEntity
    {
        public float Speed;
        public Random random;
        public void Execute(Entity entity,ref LocalTransform transform,ref L7MoveSpeed speed)
        {
            speed.speed = Speed;
            transform.Position = new float3(0, random.NextFloat() * 100, 0);
        }
    }
}