using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DefaultNamespace.Lesson3
{
    public readonly partial struct RotateAndMoveAspect : IAspect
    {
        private readonly RefRW<LocalTransform> localTransform;
        private readonly RefRO<RotateAndMoveSpeed> speed;

        public void SetPosition(float3 position)
        {
            localTransform.ValueRW.Position = position;
        }
        
        public void Move(double elapsedTime)
        {
            localTransform.ValueRW.Position.y = (float) math.sin(elapsedTime * speed.ValueRO.moveSpeed);
        }

        public void Rotate(float deltaTime)
        {
            localTransform.ValueRW = localTransform.ValueRO.RotateY(speed.ValueRO.rotateSpeed * deltaTime);
        }

        public void RotateAndMove(double elapsedTime, float deltaTime)
        {
            localTransform.ValueRW.Position.y = (float) math.sin(elapsedTime * speed.ValueRO.moveSpeed);
            localTransform.ValueRW = localTransform.ValueRO.RotateY(speed.ValueRO.rotateSpeed * deltaTime);
        }
    }
}