using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlideNotes : MonoBehaviour, IPointerExitHandler
{
    public ShowList showlist;

    public void OnPointerExit(PointerEventData eventData)
    {
        showlist.opening = false;
    }
}
