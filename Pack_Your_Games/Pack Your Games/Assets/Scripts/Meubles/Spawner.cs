using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] pieces;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Vector3 scale;
    [SerializeField] Canvas canvas;

    public void SpawnRandomBlock()
    {
        var spawnedPiece = Instantiate(pieces[Random.Range(0, pieces.Length)]);
        spawnedPiece.transform.parent = canvas.transform;
        spawnedPiece.GetComponent<RectTransform>().localPosition = spawnPosition;
        spawnedPiece.GetComponent<RectTransform>().localScale = scale;
        spawnedPiece.GetComponent<DragNDrop>().canvas = canvas;
    }

}
