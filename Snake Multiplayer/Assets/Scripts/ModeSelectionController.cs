using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeSelectionController : MonoBehaviour
{
    public Button singlePlayerButton; // Button for single-player mode
    public Button multiPlayerButton;  // Button for multiplayer mode
    public GameObject modeSelectionPopup; // The popup UI

    void Start()
    {
        // Ensure the popup is hidden at the start
        //modeSelectionPopup.SetActive(false);

        // Assign functions to the buttons
        singlePlayerButton.onClick.AddListener(StartSinglePlayer);
        multiPlayerButton.onClick.AddListener(StartMultiPlayer);
    }

    public void ShowPopup()
    {
        Debug.Log("ShowPopup called");  // Log when popup is called
        modeSelectionPopup.SetActive(true);  // Show the popup
        modeSelectionPopup.transform.SetAsLastSibling();  // Ensure the popup appears on top of other UI elements
    }

    public void HidePopup()
    {
        modeSelectionPopup.SetActive(false); // Hide the popup
    }

    private void StartSinglePlayer()
    {
        // Load the single-player scene (Scene index 1)
        SceneManager.LoadScene(1);
    }

    private void StartMultiPlayer()
    {
        // Load the multiplayer scene (Scene index 2)
        SceneManager.LoadScene(2);
    }
}