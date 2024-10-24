using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{

    public Button startButton;
    public Button quitButton;

    void Start()
    {
        // Assign functions to the button click events
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }
    public void StartGame()
    {
        // Load the scene with build index 1 (Scene number 1)
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(1);
    }

    // Method to handle Quit Button Click
    public void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        // Load the scene with build index 2 (Scene number 2)
        SceneManager.LoadScene(2);
    }

}
