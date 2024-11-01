using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

    }

    private void Start()
    {

        if (scoreText == null)
        {
            Debug.LogError("Score TextMeshProUGUI is not assigned in the inspector.");
            return;
        }
        RefreshUI();
    }

    //increase score
    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI();

        if (score >= 15)
        {
            SceneManager.LoadScene(4); // Ensure scene 4 is set in build settings
        }
    }
    public void ResetScore()
    {
        score = 0;
        RefreshUI();
    }
    public void RefreshUI()
    {
        scoreText.text = "Player A:" + score;

    }
}
