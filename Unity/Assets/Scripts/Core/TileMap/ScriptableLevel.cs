using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableLevel : ScriptableObject
{
    public int levelIndex;
    public List<SavedTiles> SavedTiles;
}

[Serializable]
public class SavedTiles
{
    public Vector3Int position;
    public ResourceTile tile;
}

public class ScriptableLevelServer
{
    public string LevelName;
    public List<ServerData> SavedData;
}

[Serializable]
public class ServerData
{
    public int PosX;
    public int PosY;
    public string ResourceType;
}
