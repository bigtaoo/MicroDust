using ET;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class MapGenerator
{
	[StaticField]private static readonly System.Random random = new();
	[StaticField]private static readonly Array tileTypes = Enum.GetValues(typeof(TileType));

	public static List<SavedTiles> GenerateRandomMap()
	{
		var result = new List<SavedTiles>();
		for (int i = -75; i < 75; ++i)
		{
			for (int j = -75; j < 75; ++j)
			{
				var tile = new SavedTiles
				{
					position = new Vector3Int(i, j, 0),
					tile = new ResourceTile
					{
						type = GenerateTileType(i, j),
					},
                };
				result.Add(tile);
			}
		}

		return result;
	}

	private static TileType GenerateTileType(int x, int y)
	{
		return (TileType)(tileTypes.GetValue(random.Next(tileTypes.Length)));
	}
}

