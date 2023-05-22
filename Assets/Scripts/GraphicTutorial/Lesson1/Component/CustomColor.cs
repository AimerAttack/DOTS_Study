using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;

namespace GraphicTutorial.Lesson1
{
    [MaterialProperty("_BaseColor")]
    struct CustomColor : IComponentData
    {
        public float4 customColor;
    }
}