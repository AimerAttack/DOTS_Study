using GraphicTutorial.Lesson1.Group;
using Unity.Burst;
using Unity.Entities;

namespace GraphicTutorial.Lesson1.System
{
    [UpdateInGroup(typeof(gl1Group))]
    public partial struct UpdateSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PrefabGenerater>();       
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {

        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}