using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] BoxCollider2D[] colliders;

    public void EnableColliders()
    {
        foreach(BoxCollider2D collider in colliders)
        {
            collider.enabled = true;
        }
    }

    public void DisableColliders()
    {
        foreach (BoxCollider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }
}
