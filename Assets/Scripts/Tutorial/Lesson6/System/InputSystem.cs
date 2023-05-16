using DefaultNamespace.Lesson6.Authoring;
using DefaultNamespace.Lesson6.Group;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace DefaultNamespace.Lesson6.System
{
    [BurstCompile]
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(Lesson6Group))]
    public partial struct InputSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<WayPoint>();
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }

        // [BurstCompile]
        //因为OnUpdate中使用了Camera的托管对象，所以这里关闭BurstCompile
        public void OnUpdate(ref SystemState state)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var path = SystemAPI.GetSingletonBuffer<WayPoint>();
                var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var newWayPoint = new float3(worldPos.x, worldPos.z, 0);
                if (path.Length > 0)
                {
                    var minDist = float.MaxValue;
                    var index = path.Length;

                    for (int i = 0; i < path.Length; i++)
                    {
                        var dist = math.distance(path[i].point, newWayPoint);
                        if(dist < minDist)
                        {
                            minDist = dist;
                            index = i;
                        }
                    }
                    
                    path.Insert(index,new WayPoint(){point = newWayPoint});
                }
            }
        }
    }
}