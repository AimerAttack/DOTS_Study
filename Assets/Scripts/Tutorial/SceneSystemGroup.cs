using Unity.Entities;
using Unity.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public abstract partial class SceneSystemGroup : ComponentSystemGroup
    {
        protected abstract string SceneName { get; }
        private bool initialized;
        protected override void OnCreate()
        {
            base.OnCreate();
            initialized = false;
        }

        protected override void OnUpdate()
        {
            if (!initialized)
            {
                Debug.Log("SceneGroup:" + SceneName);
                if (SceneManager.GetActiveScene().isLoaded)
                {
                    var subScene = Object.FindObjectOfType<SubScene>();
                    if (subScene != null)
                    {
                        Enabled = SceneName == subScene.gameObject.scene.name;
                    }
                    else
                    {
                        Enabled = false;
                    }

                    initialized = true;
                }
            }
            base.OnUpdate();
        }
    }
}