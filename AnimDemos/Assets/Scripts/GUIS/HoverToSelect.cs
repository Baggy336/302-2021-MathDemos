using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverToSelect : MonoBehaviour, IPointerEnterHandler
{
    Selectable bttn;
    void Start()
    {
        bttn = GetComponent<Selectable>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        bttn.Select();
    }
}
