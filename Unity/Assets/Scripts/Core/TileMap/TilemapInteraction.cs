//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class TilemapInteraction : MonoBehaviour
//{
//    [SerializeField] private Tilemap tileMapResources;
//    [SerializeField] private Tilemap tileMapBuildings;

//    private BuildingResources buildingResources;

//    // Start is called before the first frame update
//    void Start()
//    {
//        buildingResources = FindObjectOfType<BuildingResources>();
//        DrawMajorCity(new Vector3Int(0, 0, 0));
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//            var tpos = tileMapResources.WorldToCell(worldPoint);
//            tpos.z = 0;
//            var tile = tileMapResources.GetTile(tpos) as ResourceTile;
//            Debug.Log($"name:{tile.name}, type:{tile.type.ToString()}, x:{tpos.x}, y:{tpos.y}");
//        }
//    }

//    void DrawMajorCity(Vector3Int pos)
//    {
//        tileMapBuildings.SetTile(pos, buildingResources.MajorCity1);

//        tileMapBuildings.SetTile(new Vector3Int((pos.x + 0), (pos.y - 1)), buildingResources.MajorCity2);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x + 0), (pos.y + 1)), buildingResources.MajorCity2);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x - 1), (pos.y - 1)), buildingResources.MajorCity2);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x - 1), (pos.y + 1)), buildingResources.MajorCity2);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x - 1), (pos.y + 0)), buildingResources.MajorCity2);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x + 1), (pos.y + 0)), buildingResources.MajorCity2);

//        tileMapBuildings.SetTile(new Vector3Int((pos.x + 0), (pos.y - 2)), buildingResources.MajorCity3);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x + 0), (pos.y + 2)), buildingResources.MajorCity3);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x - 1), (pos.y - 2)), buildingResources.MajorCity3);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x - 1), (pos.y + 2)), buildingResources.MajorCity3);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x - 2), (pos.y + 0)), buildingResources.MajorCity3);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x + 2), (pos.y + 0)), buildingResources.MajorCity3);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x - 2), (pos.y + 1)), buildingResources.MajorCity3);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x - 2), (pos.y - 1)), buildingResources.MajorCity3);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x + 1), (pos.y + 1)), buildingResources.MajorCity3);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x + 1), (pos.y + 2)), buildingResources.MajorCity3);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x + 1), (pos.y - 1)), buildingResources.MajorCity3);
//        tileMapBuildings.SetTile(new Vector3Int((pos.x + 1), (pos.y - 2)), buildingResources.MajorCity3);
//    }
//}
