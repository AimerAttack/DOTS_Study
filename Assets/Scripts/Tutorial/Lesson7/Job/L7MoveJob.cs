using System;
using DefaultNamespace.Lesson7.Authoring;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace DefaultNamespace.Lesson7.Job
{
    [BurstCompile]
    public partial struct L7MoveJob : IJobEntity
    {
        public float deltaTime;
        [NativeDisableParallelForRestriction]public ComponentLookup<L7MoveSpeed> m_RotateSpeedLookup;
        [NativeDisableParallelForRestriction]public ComponentLookup<LocalTransform> transformLookup;
        [NativeDisableParallelForRestriction] public ComponentLookup<L7RotateSpeedComponentData> rotationLookup;
        public void Execute( Entity entity)
        {
            var transform = transformLookup[entity];
            var speed = m_RotateSpeedLookup[entity];

            var position = transform.Position;
            position.x += speed.speed * deltaTime;
            transform.Position = position;
            transformLookup[entity] = transform;

            if (position.x > 20)
            {
                rotationLookup.SetComponentEnabled(entity,false);
            }
            else if (position.x > 100)
            {
                rotationLookup.SetComponentEnabled(entity,true);
            }
        }
    }
}