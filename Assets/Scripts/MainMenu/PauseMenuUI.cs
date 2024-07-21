using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [Header("Pause Menu Buttons")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private GameObject pauseMenuPanel;

    private void Awake()
    {
        resumeButton.onClick.AddListener(OnResumeButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnDestroy()
    {
        resumeButton.onClick.RemoveListener(OnResumeButtonClicked);
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        quitButton.onClick.RemoveListener(OnQuitButtonClicked);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnResumeButtonClicked()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
