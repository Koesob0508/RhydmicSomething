using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StageManager))]
public class StageManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        StageManager stageManager = (StageManager)target;
        
        if(GUILayout.Button("Stage Clear"))
        {
            stageManager.StageClear();
        }

        if(GUILayout.Button("Player Clear"))
        {
            stageManager.PlayerClear();
        }

        if(GUILayout.Button("Enemy Clear"))
        {
            stageManager.EnemyClear();
        }
    }
}
