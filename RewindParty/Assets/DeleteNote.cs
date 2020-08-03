using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteNote : MonoBehaviour
{
    public Transform parentCanvas;

    private bool getDeleted = false;
    private float speed = 500;

    public void DestroyNote()
    {
        transform.SetParent(transform.parent.parent);
        getDeleted = true;
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        if (getDeleted)
        {
            transform.position += (Vector3)Vector2.right * Time.deltaTime * speed;
        }
    }
}
