using UnityEngine;
using UnityEngine.Tilemaps;

public class InverseTilemapGenerator : MonoBehaviour
{
    public Tilemap sourceTilemap;
    public Tilemap inverseTilemap;
    public TileBase fillTile;      
    public Vector2Int size = new Vector2Int(100, 100);
    public Vector3Int origin = Vector3Int.zero;

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        inverseTilemap.ClearAllTiles();
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3Int pos = new Vector3Int(origin.x + x, origin.y + y, 0);
                if (!sourceTilemap.HasTile(pos))
                {
                    inverseTilemap.SetTile(pos, fillTile);
                }
            }
        }
    }
}
