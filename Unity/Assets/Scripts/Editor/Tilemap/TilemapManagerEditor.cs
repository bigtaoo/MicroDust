using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ET
{
    [CustomEditor(typeof(TilemapManager))]
    public class TilemapManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var script = (TilemapManager)target;
            if (GUILayout.Button("Save Map"))
            {
                script.Savemap();
            }
            if (GUILayout.Button("Save Server Data"))
            {
                script.SaveServerData();
            }
            if (GUILayout.Button("Clear Map"))
            {
                script.ClearMap();
            }
            if (GUILayout.Button("Load Map"))
            {
                script.LoadMap();
            }
            if (GUILayout.Button("Generate Map"))
            {
                script.GenerateMap();
            }
        }
    }
}
