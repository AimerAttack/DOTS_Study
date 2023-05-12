using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DefaultNamespace.Lesson3
{
    [BurstCompile]
    [UpdateInGroup(typeof(CubeEntitiesByPrefabSystemGroup))]
    public partial struct CubeGenerateByPrefabSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            //只有CubeGeneratorByPrefab存在时，该System才会运行
            state.RequireForUpdate<CubeGeneratorByPrefab>();
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var generator = SystemAPI.GetSingleton<CubeGeneratorByPrefab>();
            var cubes = CollectionHelper.CreateNativeArray<Entity>(generator.cubeCount, Allocator.Temp);
            state.EntityManager.Instantiate(generator.cubeEntityProtoType, cubes);

            var count = 0;
            foreach (var cube in cubes)
            {
                state.EntityManager.AddComponentData<RotateAndMoveSpeed>(cube, new RotateAndMoveSpeed()
                {
                    rotateSpeed = count * math.radians(60),
                    moveSpeed = count
                });

                var position = new float3((count - generator.cubeCount * 0.5f) * 1.2f, 0, 0);
                var aspect = SystemAPI.GetAspectRW<RotateAndMoveAspect>(cube);
                aspect.SetPosition(position);
                count++;
            }

            cubes.Dispose();
            //此System只在启动时运行一次，所以在第一次更新后关闭它
            state.Enabled = false;
        }
    }
}