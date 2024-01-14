using System;
using Leaderboard;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private WindowManager windowManager = default;
        [SerializeField] private CanvasGroup homeCanvasGroup = default;

        private void Awake()
        {
            windowManager.OnWindowOpened += HideHome;
            windowManager.OnWindowClosed += ShowHome;
        }

        public void StartGamePressed()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void OpenLeaderboard()
        {
            windowManager.Open<LeaderboardWindow>();
        }

        public void ExitPressed()
        {
            #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
            #else
            Application.Quit();
            #endif
        }

        private void HideHome()
        {
            homeCanvasGroup.alpha = 0f;
            homeCanvasGroup.blocksRaycasts = false;
        }

        public void ShowHome()
        {
            homeCanvasGroup.alpha = 1f;
            homeCanvasGroup.blocksRaycasts = true;
        }
    }
}
