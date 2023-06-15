using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{

    private int randomValue;
    private float timeInterval;

    public bool reelStopped;
    public string stoppedSlot;

    void Start()
    {
        reelStopped = true;
        //when StartPressed occurs, Rotation of the Reels are triggered
        GameControl.StartPressed += StartRotating;
    }

    private void StartRotating()
    {
        stoppedSlot = "";
        StartCoroutine("Rotate");
    }

    //exact positionings of symbols, and for their movement
    private IEnumerator Rotate()
    {
        reelStopped = false;
        timeInterval = 0.025f;

        for (int i = 0; i < 30; i++)
        {
            if (transform.position.y <= -3.85f)
                transform.position = new Vector2(transform.position.x, 3.77f);

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);

            yield return new WaitForSeconds(timeInterval);
        }

        randomValue = Random.Range(60, 100);

        //attempt to fix their positions if not exactly stopped at symbol
        switch (randomValue % 3)
        {
            case 1:
                randomValue += 2;
                break;
            case 2:
                randomValue += 1;
                break;  
        }

        for (int i = 0; i < randomValue; i++)
        {
            if (transform.position.y <= -3.85f)
                transform.position = new Vector2(transform.position.x, 3.77f);

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);

            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.05f;
            if (i > Mathf.RoundToInt(randomValue * 1f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomValue * 1.5f))
                timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(randomValue * 2f))
                timeInterval = 2f;

            yield return new WaitForSeconds(timeInterval);
        }

        if (transform.position.y == -3.85f)
            stoppedSlot = ("CH");
        else if (transform.position.y == -1.77f)
            stoppedSlot = ("LP");
        else if (transform.position.y == 0f)
            stoppedSlot = ("GB");
        else if (transform.position.y == 1.9f)
            stoppedSlot = ("CC");
        else if (transform.position.y == 3.77f)
            stoppedSlot = ("CK");

        reelStopped = true;
    }

    private void OnDestroy()
    {
        GameControl.StartPressed -= StartRotating;
    }
}
