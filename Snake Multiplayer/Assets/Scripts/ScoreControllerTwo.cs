using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreControllerTwo : BaseScoreController
{
    private new void Start()
    {
        playerName = "Player B"; // Assign specific player name
        base.Start(); // Call base class Start to initialize UI
    }

    public override void IncreaseScore(int increment)
    {
        base.IncreaseScore(increment); // Use the base method to increase the score and update the UI
    }


    
}
