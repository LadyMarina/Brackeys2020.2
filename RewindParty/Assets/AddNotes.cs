using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNotes : MonoBehaviour
{
    [SerializeField] private GameObject note;

    public void AddNote(Text text)
    {
        GameObject newNote = Instantiate(note, transform);

        newNote.transform.GetChild(0).GetComponent<Text>().text = text.text;

        GameManager.instance.AddNote(text.text);
    }

    private void Start()
    {
        print("eee");

        print(GameManager.instance);

        foreach (string item in GameManager.instance.notes)
        {
           

            GameObject newNote = Instantiate(note, transform);

            newNote.transform.GetChild(0).GetComponent<Text>().text = item;
        }
    }
}
