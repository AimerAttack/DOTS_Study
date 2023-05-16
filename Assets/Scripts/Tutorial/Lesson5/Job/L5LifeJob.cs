using DefaultNamespace.Lesson5.Authoring;
using Unity.Burst;
using Unity.Entities;

namespace DefaultNamespace.Lesson5.Job
{
    [BurstCompile]
    public partial struct L5LifeJob : IJobEntity
    {
        public void Execute([ChunkIndexInQuery] int chunkIndex, Entity entity,ref L5CubeLife lifeComponent)
        {
            lifeComponent.life = 10;
        }
    }
}