using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowList : MonoBehaviour , IPointerEnterHandler
{
    [SerializeField] private Transform listObject;

    private Vector2 listPosition;

    public Vector2 finalListPosition;
    [Range(0f, 1f)] public float lerpValue;

    public bool opening;

    private void Start()
    {
        listPosition = listObject.localPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        opening = true;
    }

    private void Update()
    {
        if (opening)
        {
            listObject.localPosition = Vector2.Lerp(listObject.localPosition, finalListPosition, lerpValue);
        }
        else
        {
            listObject.localPosition = Vector2.Lerp(listObject.localPosition, listPosition, lerpValue);
        }
    }

  
}
