using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLegacy : MonoBehaviour
{
    public static GameManagerLegacy instance;

    public List<string> notes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        notes = new List<string>();
    }

    public void AddNote(string text)
    {
        notes.Add(text);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene(1);
        }
    }
}
