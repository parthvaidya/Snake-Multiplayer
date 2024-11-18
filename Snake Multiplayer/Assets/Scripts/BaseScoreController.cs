using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    protected int score = 0;
    public string playerName = "Player";

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("Score TextMeshProUGUI is not assigned in the inspector.");
            return;
        }
        RefreshUI();
    }

    public virtual void IncreaseScore(int increment)
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

    protected void RefreshUI()
    {
        scoreText.text = playerName + ": " + score;
    }
}
