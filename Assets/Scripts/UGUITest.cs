using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UGUITest : MonoBehaviour
{
    private void OnGUI()
    {
        var go = EventSystem.current.IsPointerOverGameObject();
        GUILayout.Label(go.ToString());
    }
}