using Unity.Burst;
using Unity.Entities;
using Unity.Entities.Content;
using UnityEngine;

namespace Resource
{
    [UpdateInGroup(typeof(ResourceGroup))]
    public partial struct ResourceSystem : ISystem,ISystemStartStop
    {
        private bool loading;
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<WeakObjectData>();
        }

        public void OnUpdate(ref SystemState state)
        {
            if (loading)
            {
                var holder = SystemAPI.GetSingleton<WeakObjectData>();
                if (holder.prefab.LoadingStatus == ObjectLoadingStatus.Completed)
                {
                    loading = false;
                    Debug.Log(Time.frameCount + "load finish");
                    GameObject.Instantiate(holder.prefab.Result);
                }
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }

        public void OnStartRunning(ref SystemState state)
        {
            loading = true;
            Debug.Log(Time.frameCount + "Resource System Start Running");
            var holder = SystemAPI.GetSingleton<WeakObjectData>();
            holder.prefab.LoadAsync();
        }

        [BurstCompile]
        public void OnStopRunning(ref SystemState state)
        {
            
        }
    }
}