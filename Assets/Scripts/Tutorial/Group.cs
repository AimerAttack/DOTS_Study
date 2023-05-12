using DefaultNamespace;
using Unity.Entities;

public partial class Lesson0SystemGroup : ComponentSystemGroup
{
    
}

[UpdateInGroup(typeof(Lesson0SystemGroup))]
public partial class CubeRotateSystemGroup : SceneSystemGroup
{
    protected override string SceneName => "RotateCubeAuthoring";
}

[UpdateInGroup(typeof(Lesson0SystemGroup))]
public partial class CubeRotateWithIJobEntitySystemGroup : SceneSystemGroup
{
    protected override string SceneName => "RotateCubeWithIJobEntityAuthoring";
}

[UpdateInGroup(typeof(Lesson0SystemGroup))]
public partial class CubeEntitiesByPrefabSystemGroup : SceneSystemGroup
{
    protected override string SceneName => "CubeEntitiesByPrefab";
}