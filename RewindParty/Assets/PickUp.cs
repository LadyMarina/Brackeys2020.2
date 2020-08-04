using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject pickedObject;
    private bool pickedUp = true;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            pickedUp = true;
        }
        if (pickedObject)
        {
            if (Input.GetKey(KeyCode.E) && pickedUp)
            {
                Bucket buckedObj = pickedObject.GetComponent<Bucket>();
                if (buckedObj && buckedObj.GetState() != Bucket.Liquid.NonFilled)
                {
                    buckedObj.ThrowLiquid();
                }
                else
                {
                    pickedObject.transform.parent = null;
                    pickedObject.GetComponent<Collider2D>().enabled = true;
                    pickedObject = null;
                }
                pickedUp = false;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PickableObj") && Input.GetKey(KeyCode.E) && pickedUp && !pickedObject)
        {
            pickedObject = collision.gameObject;
            pickedObject.transform.parent = gameObject.transform;
            pickedObject.GetComponent<Collider2D>().enabled = false;
            pickedUp = false;
        }
    }
}
