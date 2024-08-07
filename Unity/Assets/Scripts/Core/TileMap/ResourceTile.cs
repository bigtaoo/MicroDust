using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New resource tile", menuName = "2D/Tiles/Resource Tile")]
public class ResourceTile : Tile
{
    public TileType type;
}

[Serializable]
public enum TileType
{
    Blank,
    Mountain,
    River,
    Food1 = 100,
    Food2,
    Food3,
    Food4,
    Food5,
    Food6,
    Food7,
    Food8,
    Food9,
    Food10,
    Iron1 = 200,
    Iron2,
    Iron3,
    Iron4,
    Iron5,
    Iron6,
    Iron7,
    Iron8,
    Iron9,
    Iron10,
    Wood1 = 300,
    Wood2,
    Wood3,
    Wood4,
    Wood5,
    Wood6,
    Wood7,
    Wood8,
    Wood9,
    Wood10,
    Stone1 = 400,
    Stone2,
    Stone3,
    Stone4,
    Stone5,
    Stone6,
    Stone7,
    Stone8,
    Stone9,
    Stone10,
    Gold6 = 500,
    Gold7,
    Gold8,
    Gold9,
    Gold10,
    MajorCity = 600,
    Army,
}
