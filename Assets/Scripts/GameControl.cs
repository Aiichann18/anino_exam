 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameControl : MonoBehaviour
{
    //what happens when the button is pressed
    public static event Action StartPressed = delegate { };

    //using SerializeField to be editable later on in Unity
    //used to control prizeText
    [SerializeField]
    private Text prizeText;

    //Help info about reels
    [SerializeField]
    private Row[] reel;

    //holds the data of the winning
    private int prizeValue;

    //resultsChecked is automatically set to false to stop multiple checking when reels arent rotating
    private bool resultsChecked = false;


    void Update()
    {
        //checks if any of the reels are still spinning
        if (!reel[0].reelStopped || !reel[1].reelStopped || !reel[2].reelStopped || !reel[3].reelStopped || !reel[4].reelStopped)
        {
            //if there are still any rotating reel, value of the prize is 0 and text will not show yet.
            //resultschecked will not yet initiate
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
        }
        //checks if all reels have stopped spinnning, and results have not been checked
        if (reel[0].reelStopped && reel[1].reelStopped && reel[2].reelStopped && reel[3].reelStopped && reel[4].reelStopped && !resultsChecked)
        {
            //then results are checked which will indicate the winning value in the text
            CheckResults();
            prizeText.enabled = true;
            prizeText.text = "Prize: " + prizeValue;
        }
    }

    //although usually for left mouse button, can be used for finger touch to trigger Spin button
    private void OnMouseDown()
    {
        if (reel[0].reelStopped && reel[1].reelStopped && reel[2].reelStopped && reel[3].reelStopped && reel[4].reelStopped)
            StartPressed();
    }

        private void CheckResults()
    {
        if (reel[0].stoppedSlot == "CH" && reel[1].stoppedSlot == "CH" && reel[2].stoppedSlot == "CH" && reel[3].stoppedSlot == "CH" && reel[4].stoppedSlot == "CH")
            prizeValue = 50;

        else if (reel[0].stoppedSlot == "LP" && reel[1].stoppedSlot == "LP" && reel[2].stoppedSlot == "LP" && reel[3].stoppedSlot == "LP" && reel[4].stoppedSlot == "LP")
            prizeValue = 100;

        else if (reel[0].stoppedSlot == "GB" && reel[1].stoppedSlot == "GB" && reel[2].stoppedSlot == "GB" && reel[3].stoppedSlot == "GB" && reel[4].stoppedSlot == "GB")
            prizeValue = 200;

        else if (reel[0].stoppedSlot == "CC" && reel[1].stoppedSlot == "CC" && reel[2].stoppedSlot == "CC" && reel[3].stoppedSlot == "CC" && reel[4].stoppedSlot == "CC")
            prizeValue = 500;

        else if (reel[0].stoppedSlot == "CK" && reel[1].stoppedSlot == "CK" && reel[2].stoppedSlot == "CK" && reel[3].stoppedSlot == "CK" && reel[4].stoppedSlot == "CK")
            prizeValue = 1000;

        else if (reel[0].stoppedSlot == "MT" && reel[1].stoppedSlot == "MT" && reel[2].stoppedSlot == "MT" && reel[3].stoppedSlot == "MT" && reel[4].stoppedSlot == "MT")
            prizeValue = 10;

        else if (reel[0].stoppedSlot == "PM" && reel[1].stoppedSlot == "PM" && reel[2].stoppedSlot == "PM" && reel[3].stoppedSlot == "PM" && reel[4].stoppedSlot == "PM")
            prizeValue = 20;

        resultsChecked = true;
    }
}