using DefaultNamespace.Lesson5.Authoring;
using Unity.Entities;

namespace DefaultNamespace.Lesson5.Aspect
{
    public readonly partial struct L5CubeAspect : IAspect
    {
        private readonly RefRW<L5CubeLife> LifeComponent;

        public void SetLife(float life)
        {
            LifeComponent.ValueRW.life = life;
        }
    }
}