using DefaultNamespace.Lesson5.Authoring;
using Unity.Entities;

namespace DefaultNamespace.Lesson5.Job
{
    public partial struct L5LifeUpdateJob : IJobEntity
    {
        public float deltaTime;
        public EntityCommandBuffer.ParallelWriter Writer;

        public void Execute([ChunkIndexInQuery] int chunkIndex, Entity entity, ref L5CubeLife lifeComponent)
        {
            if (lifeComponent.life > deltaTime)
            {
                lifeComponent.life -= deltaTime;
            }
            else
            {
                Writer.DestroyEntity(chunkIndex, entity);
            }
        }
    }
}