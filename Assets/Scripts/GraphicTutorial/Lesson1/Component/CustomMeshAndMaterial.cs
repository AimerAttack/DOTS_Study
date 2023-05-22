using Unity.Entities;
using UnityEngine;

namespace GraphicTutorial.Lesson1
{
    class CustomMeshAndMaterial : IComponentData
    {
        public Mesh Mesh1;
        public Mesh Mesh2;
        
        public Material Mat1;
        public Material Mat2;
    }
}