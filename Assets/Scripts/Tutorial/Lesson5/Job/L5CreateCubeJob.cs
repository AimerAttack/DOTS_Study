using DefaultNamespace.Lesson5.Aspect;
using DefaultNamespace.Lesson5.Authoring;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace DefaultNamespace.Lesson5.Job
{
    [BurstCompile]
    partial struct L5CreateCubeJob : IJobFor
    {
        [ReadOnly]public Entity ArcheType;
        public NativeArray<Entity> Cubes;
        public EntityCommandBuffer.ParallelWriter Writer;
        public float life;
        

        public void Execute(int index)
        {
            Cubes[index] = Writer.Instantiate(index, ArcheType);
            Debug.Log($"{index}");
        }
    }
}