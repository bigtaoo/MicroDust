using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] private Tilemap resourceTilemap;
    [SerializeField] private int levelIndex;
    [SerializeField] private List<ResourceTile> resourceTiles;

    public void Savemap()
    {
        var newLevel = ScriptableObject.CreateInstance<ScriptableLevel>();

        newLevel.levelIndex = levelIndex;
        newLevel.name = $"Level {levelIndex}";
        newLevel.SavedTiles = GetTilesFromMap(resourceTilemap).ToList();

#if UNITY_EDITOR
        ScriptableObjectUtility.SaveLevelFile(newLevel);
#endif

        IEnumerable<SavedTiles> GetTilesFromMap(Tilemap map)
        {
            foreach(var pos in map.cellBounds.allPositionsWithin)
            {
                if (map.HasTile(pos))
                {
                    var levelTile = map.GetTile<ResourceTile>(pos);
                    if (levelTile != null)
                    {
                        yield return new SavedTiles()
                        {
                            position = pos,
                            tile = levelTile
                        };
                    }
                }
            }
        }
    }

    public void ClearMap()
    {
        var maps = FindObjectsOfType<Tilemap>();
        foreach (var map in maps)
        {
            map.ClearAllTiles();
        }
    }

    public void LoadMap()
    {
        var level = Resources.Load<ScriptableLevel>($"Levels/level {levelIndex}");
        if (level == null)
        {
            Debug.LogError($"Level {levelIndex} does not exist.");
            return;
        }

        ClearMap();

        foreach (var tile in level.SavedTiles)
        {
            resourceTilemap.SetTile(tile.position, tile.tile);
        }
    }

    public void GenerateMap()
    {
        var tiles = MapGenerator.GenerateRandomMap();
        foreach(var tile in tiles)
        {
            var r = resourceTiles.First(t => t.type == tile.tile.type);
            tile.tile = r;
        }

        var newLevel = ScriptableObject.CreateInstance<ScriptableLevel>();

        newLevel.levelIndex = levelIndex;
        newLevel.name = $"Level {levelIndex}";
        newLevel.SavedTiles = tiles;

#if UNITY_EDITOR
        ScriptableObjectUtility.SaveLevelFile(newLevel);
#endif

        LoadMap();
    }

    public void SaveServerData()
    {
        var newLevel = new ScriptableLevelServer();

        newLevel.LevelName = levelIndex.ToString();
        newLevel.SavedData = GetTilesFromMap(resourceTilemap).ToList();

#if UNITY_EDITOR
        ScriptableObjectUtility.SaveLevelServerData(newLevel);
#endif

        IEnumerable<ServerData> GetTilesFromMap(Tilemap map)
        {
            foreach (var pos in map.cellBounds.allPositionsWithin)
            {
                if (map.HasTile(pos))
                {
                    var levelTile = map.GetTile<ResourceTile>(pos);
                    if (levelTile != null)
                    {
                        yield return new ServerData()
                        {
                            PosX = pos.x,
                            PosY = pos.y,
                            ResourceType = levelTile.type.ToString(),
                        };
                    }
                }
            }
        }
    }
}


