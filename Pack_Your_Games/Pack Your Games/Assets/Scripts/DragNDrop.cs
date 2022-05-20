using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private SpriteRenderer spriteRenderer;
    //[SerializeField] private int tileCases;
    //[SerializeField] private GameManager gameManager;
    //private bool valid;
    private RectTransform rectTransform;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void OnBeginDrag(PointerEventData enventData)
    {
        Debug.Log("OnBeginDrag");
        if (spriteRenderer != null)
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.85f);
        boxCollider.enabled = false;
    }

    public void OnDrag(PointerEventData enventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += enventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData enventData)
    {
        Debug.Log("OnEndDrag");
        if (spriteRenderer != null)
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        boxCollider.enabled = true;
    }

    public void OnPointerDown(PointerEventData enventData)
    {
        Debug.Log("OnPointerDown");
    }

    /**public void isValid()
    {
        int coveredThisTile = gameManager.NumberCoveredThisTile();
        valid = (coveredThisTile == tileCases);
        Debug.Log("Valid = " + valid);
    }

    public bool GetValid() {return valid;}*/
}
