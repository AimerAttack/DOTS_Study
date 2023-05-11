using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Jobs;

namespace DefaultNamespace
{

    [BurstCompile]
    struct WaveCubesJob : IJobParallelForTransform
    {
        [ReadOnly] public float deltaTime;
        
        public void Execute(int index, TransformAccess transform)
        {
            var distance = Vector3.Distance(transform.position, Vector3.zero);
            transform.localPosition += Vector3.up * math.sin(deltaTime * 3f + distance * 0.2f);
        }
    }
    
    public class WaveCubesWithJob : MonoBehaviour
    {
        public GameObject cubeAchetype;
        [Range(10, 100)] public int xHalfCount = 40;
        [Range(10, 100)] public int zHalfCount = 40;
        
        private static readonly ProfilerMarker<int> profilerMarker =
            new ProfilerMarker<int>("WaveCubes UpdateTransform", "Object Count");

        private TransformAccessArray transformAccessArray;

        private void Start()
        {
            transformAccessArray = new TransformAccessArray(4 * xHalfCount * zHalfCount);
            for (int z = -zHalfCount; z <= zHalfCount; z++)
            {
                for (int x = -xHalfCount; x < xHalfCount; x++)
                {
                    var cube = Instantiate(cubeAchetype);
                    cube.transform.position = new Vector3(x * 1.1f, 0, z * 1.1f);
                    transformAccessArray.Add(cube.transform);
                }
            }
        }

        private void Update()
        {
            using (profilerMarker.Auto(transformAccessArray.length))
            {
                var waveCubesJob = new WaveCubesJob
                {
                    deltaTime = Time.time
                };

                var waveCubesJobHandle = waveCubesJob.Schedule(transformAccessArray);
                waveCubesJobHandle.Complete();
            }
        }

        private void OnDestroy()
        {
            transformAccessArray.Dispose();
        }
    }
}