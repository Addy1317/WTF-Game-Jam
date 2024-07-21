using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Main Menu Button")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button storyButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    [Header("Panels Button")]
    [SerializeField] private Button storyBackButton;
    [SerializeField] private Button settingsBackButton;

    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject storyPanel;
    [SerializeField] private GameObject settingsPanel;
    
    private void Awake()
    {
        // Assign listeners to the buttons
        playButton.onClick.AddListener(OnPlayButtonClicked);
        storyButton.onClick.AddListener(OnStoryButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);

        storyBackButton.onClick.AddListener(OnStoryBackButtonClicked);
        settingsBackButton.onClick.AddListener(OnSettingsBackButtonClicked);
    }

    private void OnDestroy()
    {
        // Remove listeners to avoid memory leaks
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
        storyButton.onClick.RemoveListener(OnStoryButtonClicked);
        settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
        quitButton.onClick.RemoveListener(OnQuitButtonClicked);

        storyBackButton.onClick.RemoveListener(OnStoryBackButtonClicked);
        settingsBackButton.onClick.RemoveListener(OnSettingsBackButtonClicked);
    }

    #region Main Buttons
    private void OnPlayButtonClicked()
    {
        // Load the game scene
        SceneManager.LoadScene("Level_1");
    }

    private void OnStoryButtonClicked()
    {
        storyPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    private void OnSettingsButtonClicked()
    {
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    private void OnQuitButtonClicked()
    {
        // Quit the application
        Debug.Log("Quit button clicked");
        Application.Quit();
    }
    #endregion

    #region Panels Button
    private void OnSettingsBackButtonClicked()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    private void OnStoryBackButtonClicked()
    {
        storyPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    #endregion

}
