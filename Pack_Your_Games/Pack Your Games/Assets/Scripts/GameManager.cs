using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private GridManager gridManager;
    private static int coveredLastTile;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    public int CountPoints()
    {
        int totScore = 0;
        int gridWidth = gridManager.getWidth();
        int gridHeight = gridManager.getHeight();

        // For each Tile, we see if it's covered. If yes, +10, if not, -10.
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                if (gridManager.GetTileAtPosition(new Vector2(i, j)).GetCoveredState()) totScore += 10;
                else totScore -= 10;
            }
        }

        return totScore;
    }

    public int NumberCoveredThisTile()
    {
        int covered = 0
        int gridWidth = gridManager.getWidth();
        int gridHeight = gridManager.getHeight();

        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                if (gridManager.GetTileAtPosition(new Vector2(i, j)).GetCoveredState()) covered += 1;
            }
        }

        int coveredThisTile = covered - coveredLastTile;
        coveredLastTile = covered; //a faire au changement de tuile
        return coveredThisTile;
    }
}
