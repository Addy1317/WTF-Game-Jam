using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TreeMahgeddon.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _quitButton;

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _optionsButton.onClick.AddListener(OnOptionsButtonClicked);
            _quitButton.onClick.AddListener(OnQuitButtonClicked);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
            _optionsButton.onClick.RemoveListener(OnOptionsButtonClicked);
            _quitButton.onClick.RemoveListener(OnQuitButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            SceneManager.LoadScene("GameScene");
        }

        private void OnOptionsButtonClicked()
        {
            Debug.Log("Options button clicked");
        }

        private void OnQuitButtonClicked()
        {
            Debug.Log("Quit button clicked");
            Application.Quit();
        }
    }
}
