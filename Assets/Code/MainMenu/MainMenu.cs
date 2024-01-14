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
    }
}
