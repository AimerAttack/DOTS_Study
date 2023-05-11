using System;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

namespace DefaultNamespace
{
    public class WaveCubes : MonoBehaviour
    {
        public GameObject cubeAchetype;
        [Range(10, 100)] public int xHalfCount = 40;
        [Range(10, 100)] public int zHalfCount = 40;
        private List<Transform> cubesList;

        private static readonly ProfilerMarker<int> profilerMarker =
            new ProfilerMarker<int>("WaveCubes UpdateTransform", "Object Count");
        
        private void Start()
        {
            cubesList = new List<Transform>();
            for (int z = -zHalfCount; z <= zHalfCount; z++)
            {
                for (int x = -xHalfCount; x < xHalfCount; x++)
                {
                    var cube = Instantiate(cubeAchetype);
                    cube.transform.position = new Vector3(x * 1.1f, 0, z * 1.1f);
                    cubesList.Add(cube.transform);
                }
            }
        }

        private void Update()
        {
            using (profilerMarker.Auto(cubesList.Count))
            {
                for (int i = 0; i < cubesList.Count; i++)
                {
                    var distance = Vector3.Distance(cubesList[i].position, Vector3.zero);
                    cubesList[i].localPosition += Vector3.up * Mathf.Sin(Time.time * 3f + distance * 0.2f);
                }
            }
        }
    }
}