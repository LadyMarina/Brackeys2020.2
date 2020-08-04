using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] private GameObject liquid;
    public enum Liquid
    {
        NonFilled,
        Water,
        Vomit
    }
    private Liquid state = Liquid.NonFilled;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (state == Liquid.NonFilled && collision.GetComponent<Filler>())
        {
            state = collision.GetComponent<Filler>().liquidType;
            ColorSet();
        }
    }

    private void ColorSet()
    {
        SpriteRenderer spriteColor = GetComponent<SpriteRenderer>();
        switch (state)
        {
            case Liquid.Water:
                spriteColor.color = Color.blue;
                break;
            case Liquid.Vomit:
                spriteColor.color = Color.green;
                break;
            default:
                spriteColor.color = Color.grey;
                break;
        }
    }
    public void ThrowLiquid()
    {
        GameObject liq = Instantiate(liquid, transform.position, transform.rotation);
        liq.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
        state = Liquid.NonFilled;
        ColorSet();
    }
    public Liquid GetState()
    {
        return state;
    }
}
