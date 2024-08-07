using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New building tile", menuName = "2D/Tiles/Building Tile")]
public class BuildingTile : Tile
{
	public BuildingType type;
}

[Serializable]
public enum BuildingType
{
	MajorCity
}
