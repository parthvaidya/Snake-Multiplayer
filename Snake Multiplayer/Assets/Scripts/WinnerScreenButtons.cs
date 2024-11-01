using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerScreenButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public Button MainMenu;
    public Button quitButton;

    void Start()
    {
        // Use += to add listeners for the buttons
        MainMenu.onClick.AddListener(() => Menu());
        quitButton.onClick.AddListener(() => Quitting());
    }

    public void Menu()
    {
        // Load the main menu scene
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }

    public void Quitting()
    {
        // Load the quit or exit scene
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(3);
    }
}
