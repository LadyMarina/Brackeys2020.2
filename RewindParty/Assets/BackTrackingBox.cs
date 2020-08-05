using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class BackTrackingBox : MonoBehaviour
{
    public bool isBackTracking = true;

    private List<Vector2> trackPositions;
    private Vector2 lastTrackPos;

    private bool goingBackAnim;
    private Vector2 goingBackPos;
    [SerializeField][Range(0f,1f)] private float lerpValue = 0.1f;
    private int posIndex;

    private float time;
    [SerializeField] private float timeBetweenAnim = 0.2f;

    private void Awake()
    {
        trackPositions = new List<Vector2>();

        time = timeBetweenAnim;
    }

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Timer").GetComponent<CountDownTimer>().timeAt0.AddListener(ResetPos);
    }

    private void Update()
    {
        if (!goingBackAnim)
        {
            Vector2 newPos = BackTrackGrid.GetNearestPointOnGrid(transform.position);

            if (lastTrackPos != newPos)
            {
                trackPositions.Add(newPos);
                lastTrackPos = newPos;
            }
        }
        else
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                time = timeBetweenAnim;

                goingBackPos = trackPositions[posIndex];

                posIndex--;

                if(posIndex < 0)
                {
                    trackPositions.Clear();
                    goingBackAnim = false;
           
                }
            }

            transform.position = Vector2.Lerp(transform.position, goingBackPos, lerpValue);
        }
    }

    public void ResetPos()
    {
        goingBackAnim = true;
        posIndex = trackPositions.Count-1;

        foreach (var item in trackPositions)
        {
            print(item);
        }
    }
}
