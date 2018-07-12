using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(GameManager))]
[CanEditMultipleObjects]
public class SelfDestroyerEditor :Editor {
    
    /*public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Gameobject");
        selfDestroyer.go =(GameObject)EditorGUILayout.ObjectField(selfDestroyer.go,typeof(GameObject),false);
        selfDestroyer.timer = EditorGUILayout.IntField(selfDestroyer.timer);
        EditorGUILayout.EndHorizontal();
    }
    */
}
