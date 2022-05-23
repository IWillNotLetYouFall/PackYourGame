using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private Canvas scoreCanva;
    private int coveredLastTile;
    private bool validMove;
    private int thisTileCases;
    private DragNDrop currentDrag;

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

    private void Awake()
    {
        instance = this;
        instance.validMove = true;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EndTurn();
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

    public void PrintScore()
    {
        int coveredThisTile = NumberCovered() - coveredLastTile;
        validMove = (coveredThisTile == thisTileCases);
        
        if(instance.validMove)
        {
            scoreCanva.gameObject.SetActive(true);
            scoreText.text = CountPoints() + " pts";
        }
    }

    private int NumberCovered()
    {
        int covered = 0;
        int gridWidth = gridManager.getWidth();
        int gridHeight = gridManager.getHeight();
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                if (gridManager.GetTileAtPosition(new Vector2(i, j)).GetCoveredState()) covered += 1;
            }
        }
        return covered;
    }
    
    public void BeginTurn(int numberTileCases, DragNDrop drag)
    {
        validMove = false;
        thisTileCases = numberTileCases;
        currentDrag = drag;
    }
    // The function to call when the player finishes to put a furniture on the grid
    private void EndTurn()
    {  
        int coveredThisTile = NumberCovered() - coveredLastTile;
        validMove = (coveredThisTile == thisTileCases);
        Debug.Log("CoveredThisTile " + coveredThisTile + " TileCases " + thisTileCases);
        
        if (!instance.validMove)
        {
            Debug.Log("le move n'est pas valide !!!");
        }
        else
        {
            Debug.Log("le move est valide !");
            coveredLastTile = NumberCovered();
            spawner.SpawnRandomBlock();
            currentDrag.enabled = false;
        }
    }

}
