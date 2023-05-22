using GraphicTutorial.Lesson1.Group;
using Unity.Burst;
using Unity.Entities;
using Unity.Rendering;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace GraphicTutorial.Lesson1.System
{
    [UpdateInGroup(typeof(gl1Group))]
    public partial struct Gl1System : ISystem,ISystemStartStop
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            Debug.Log("OnCreate");
            // state.RequireForUpdate<PrefabGenerater>();       
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {

        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }

        public void OnStartRunning(ref SystemState state)
        {
            Debug.Log("OnStartRunning");
            var generaterData = SystemAPI.GetSingleton<PrefabGeneraterData>();
            var entity = state.EntityManager.Instantiate(generaterData.prefab);
            state.EntityManager.AddComponent<CustomColor>(entity);
            state.EntityManager.AddComponentData(entity, new CustomMeshAndMaterial()
            {

            });
        }

        public void OnStopRunning(ref SystemState state)
        {
            
        }
    }
}