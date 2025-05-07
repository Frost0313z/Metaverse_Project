using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapLogger : MonoBehaviour
{
    [SerializeField] private TileBase targetTile; // 확인하고 싶은 타일 (예: 문 타일)
    private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();

        if (tilemap == null)
        {
            Debug.LogError("Tilemap 컴포넌트를 찾을 수 없습니다!");
            return;
        }

        BoundsInt bounds = tilemap.cellBounds;
        Debug.Log($"타일맵 범위: {bounds}");

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(pos);

                if (tile == targetTile)
                {
                    Debug.Log($"타겟 타일 위치 발견! 셀 좌표: {pos}");
                }
            }
        }
    }
}

