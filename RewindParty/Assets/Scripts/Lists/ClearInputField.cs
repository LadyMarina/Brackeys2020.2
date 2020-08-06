using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearInputField : MonoBehaviour
{
    private InputField text;
    private void Start()
    {
        text = GetComponent<InputField>();
    }

    public void Clear()
    {
        text.text = "";
    }
}
