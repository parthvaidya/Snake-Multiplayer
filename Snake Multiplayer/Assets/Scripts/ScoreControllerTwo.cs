using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreControllerTwo : MonoBehaviour
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

    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI();
    }
    public void ResetScore()
    {
        score = 0;
        RefreshUI();

        if (score >= 15)
        {
            SceneManager.LoadScene(4); 
        }
    }
    public void RefreshUI()
    {
        scoreText.text = "Player B:" + score;

    }
}
