using System;
using Unity.Entities;
using Unity.Entities.Graphics;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Rendering;

namespace GraphicTutorial.Lesson0
{
    public class CreateEntityWithMonoBehaviour : MonoBehaviour
    {
        public Mesh mesh;
        public Material material;

        private void Start()
        {
            var world = World.DefaultGameObjectInjectionWorld;
            var entityManager = world.EntityManager;

            var renderMeshArray = new RenderMeshArray(new[] {material}, new[] {mesh});
            var renderMeshDescription = new RenderMeshDescription()
            {
                FilterSettings = RenderFilterSettings.Default,
                LightProbeUsage = LightProbeUsage.Off
            };

            var cubeEntity = entityManager.CreateEntity();
            RenderMeshUtility.AddComponents(
                cubeEntity,
                entityManager,
                renderMeshDescription,
                renderMeshArray,
                MaterialMeshInfo.FromRenderMeshArrayIndices(0,0)
                );
            entityManager.SetComponentData(cubeEntity,new LocalToWorld(){Value = float4x4.identity});
        }
    }
}