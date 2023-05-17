using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using NotImplementedException = System.NotImplementedException;

namespace DefaultNamespace.Lesson7.Job
{
    [BurstCompile]
    public partial struct L7CreateCubeJob : IJobFor
    {

        [ReadOnly] public Entity ArcheType;
        public NativeArray<Entity> Cubes;
        public EntityCommandBuffer.ParallelWriter Writer;
        
        public void Execute(int index)
        {
            Cubes[index] = Writer.Instantiate(index, ArcheType);
        }
    }
}