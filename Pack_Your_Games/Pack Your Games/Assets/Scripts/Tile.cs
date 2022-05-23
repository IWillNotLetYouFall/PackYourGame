using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IDropHandler
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private int coveredStack;

    private void Awake()
    {
        coveredStack = 0;
    }

    public bool GetCoveredState()
    {
        return coveredStack > 0;
    }

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    public void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    public void OnDrop(PointerEventData enventData)
    {
        Debug.Log("OnDrop");
        if (enventData.pointerDrag !=null)
        {
                enventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision enter " + this.name);
        coveredStack += 1;
        //GameManager.Instance.IncrementCoveredThisTile();
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Collision exit " + this.name);
        coveredStack -= 1;
    }
}
