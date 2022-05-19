using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private GridManager gridManager;

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
}
