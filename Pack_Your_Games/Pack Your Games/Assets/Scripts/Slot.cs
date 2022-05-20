using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
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
        Debug.Log("Collision " + this.name);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Collision exit " + this.name);
    }
}
