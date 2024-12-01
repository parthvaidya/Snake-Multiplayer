using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{

    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button chooseMode;
    [SerializeField] private ModeSelectionController modeSelectionController;
    [SerializeField] private GameObject modeSelectionPopup;

    void Start()
    {
        // Assign functions to the button click events
        startButton.onClick.AddListener(StartGame);
        chooseMode.onClick.AddListener(ChooseMode);
        quitButton.onClick.AddListener(QuitGame);
        modeSelectionPopup.SetActive(false);

    }
    private void StartGame()
    {
        // Load the scene with build index 1 (Scene number 1)
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(1);
    }

    private void ChooseMode()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        modeSelectionPopup.SetActive(true);
        //modeSelectionController.ShowPopup();
    }
    // Method to handle Quit Button Click
    private void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        // Load the scene with build index 2 (Scene number 2)
        SceneManager.LoadScene(3);
    }

}
