using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    [SerializeField] private Button restarting;
    [SerializeField] private Button Quitgame;

    private void Awake()
    {
        restarting.onClick.AddListener(Restartgame);
        Quitgame.onClick.AddListener(quitthegame);
    }
    public void SnakeDied()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void Restartgame()
    {
        Time.timeScale = 1;
        //SceneManager.LoadScene(0);
        Scene currentScene = SceneManager.GetActiveScene(); // Get the current active scene
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    private void quitthegame()
    {
        SceneManager.LoadScene(3);
    }
}
