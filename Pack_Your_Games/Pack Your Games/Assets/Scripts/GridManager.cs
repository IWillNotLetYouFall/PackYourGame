using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Vector2 _gridOffset;

    private Dictionary<Vector2, Tile> _tiles;

    public int getWidth()
    {
        return _width;
    }

    public int getHeight()
    {
        return _height;
    }

    private void Start()
    {
        GenerateGrid();
        Debug.Log("Le score initial est de : " + GameManager.Instance.CountPoints());
        
    }

    void GenerateGrid()
    {
        float xOffset = ((float) _width - 1)/ 2;
        float yOffset = ((float) _height - 1)/ 2;
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x - xOffset + _gridOffset.x, y - yOffset + _gridOffset.y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.transform.parent = canvas.transform;

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);

                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -20);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        return null;
    }
}
