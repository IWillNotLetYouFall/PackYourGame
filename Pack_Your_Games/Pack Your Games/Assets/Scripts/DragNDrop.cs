using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Piece))]
public class DragNDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int tileCases;
    private RectTransform rectTransform;
    private Piece piece;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        piece = GetComponent<Piece>();
    }

    public void OnBeginDrag(PointerEventData enventData)
    {
        Debug.Log("OnBeginDrag");
        if (spriteRenderer != null)
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.85f);
        piece.DisableColliders();

        GameManager.Instance.BeginTurn(tileCases);
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
        piece.EnableColliders();
    }

    public void OnPointerDown(PointerEventData enventData)
    {
        Debug.Log("OnPointerDown");
    }
}
