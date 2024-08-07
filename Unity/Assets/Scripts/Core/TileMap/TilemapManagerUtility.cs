#if UNITY_EDITOR

using System.IO;
using UnityEditor;
using UnityEngine;

public static class ScriptableObjectUtility
{
    public static void SaveLevelFile(ScriptableLevel level)
    {
        AssetDatabase.CreateAsset(level, $"Assets/Resources/Levels/{level.name}.asset");

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    public static void SaveLevelServerData(ScriptableLevelServer level)
    {
        //AssetDatabase.CreateAsset(level, $"Assets/Resources/Levels/{level.LevelName}.json");

        //AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();

        int count = 1;
        int index = 0;
        int max = level.SavedData.Count;
        const int steps = 10000;
        while (index <= max)
        {
            var range = max - index >= steps ? steps : max - index;
            var subset = level.SavedData.GetRange(index, range);
            var mapInfo = new ScriptableLevelServer
            {
                LevelName = $"{level.LevelName}-{count}",
                SavedData = subset,
            };
            var json = EditorJsonUtility.ToJson(mapInfo);
            var folderPath = Path.Combine(Application.dataPath, "Resources/Levels/");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var path = Path.Combine(folderPath, $"{mapInfo.LevelName}.json");
            Debug.Log("Server data saved path: " + path);
            File.WriteAllText(path, json);

            index += steps;
            count++;
        }
    }
}
#endif
