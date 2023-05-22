using System.Collections.Generic;
using GraphicTutorial.Lesson1.Group;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Rendering;

namespace GraphicTutorial.Lesson1.System
{
    [UpdateInGroup(typeof(gl1Group))]
    public partial class ChangeMeshAndMaterialSystem : SystemBase
    {
        private Dictionary<Mesh, BatchMeshID> m_MeshMapping;
        private Dictionary<Material, BatchMaterialID> m_MaterialMapping;

        protected override void OnStartRunning()
        {
            RequireForUpdate<CustomMeshAndMaterial>();
            var entitiesGraphicsSystem = World.GetOrCreateSystemManaged<EntitiesGraphicsSystem>();
            m_MeshMapping = new Dictionary<Mesh, BatchMeshID>();
            m_MaterialMapping = new Dictionary<Material, BatchMaterialID>();
            
            Entities
                .WithoutBurst()
                .ForEach((in CustomMeshAndMaterial changer) =>
                {
                    if (!m_MeshMapping.ContainsKey(changer.Mesh1))
                        m_MeshMapping[changer.Mesh1] = entitiesGraphicsSystem.RegisterMesh(changer.Mesh1);
                    if (!m_MeshMapping.ContainsKey(changer.Mesh2))
                        m_MeshMapping[changer.Mesh2] = entitiesGraphicsSystem.RegisterMesh(changer.Mesh2);
                    
                    if (!m_MaterialMapping.ContainsKey(changer.Mat1))
                        m_MaterialMapping[changer.Mat1] = entitiesGraphicsSystem.RegisterMaterial(changer.Mat1);
                    if (!m_MaterialMapping.ContainsKey(changer.Mat2))
                        m_MaterialMapping[changer.Mat2] = entitiesGraphicsSystem.RegisterMaterial(changer.Mat2);
                    
                }).Run();
        }

        protected override void OnDestroy()
        {
            m_MeshMapping.Clear();
            m_MaterialMapping.Clear();
        }

        protected override void OnUpdate()
        {
            Entities
                .WithoutBurst()
                .ForEach((CustomMeshAndMaterial changer, ref MaterialMeshInfo info, in LocalToWorld trans) =>
                {
                    if (trans.Position.y < -5)
                    {
                        info.MeshID = m_MeshMapping[changer.Mesh1];
                        info.MaterialID = m_MaterialMapping[changer.Mat1];
                    }
                    else if(trans.Position.y > 5)
                    {
                        info.MeshID = m_MeshMapping[changer.Mesh2];
                        info.MaterialID = m_MaterialMapping[changer.Mat2];
                    }
                }).Run(); 
        }
    }
}