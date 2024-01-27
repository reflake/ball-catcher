using System;
using Game;
using Game.Enum;
using Leaderboard;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private WindowManager windowManager = default;

        public void StartSurvivalGamePressed()
        {
            StartGame(GameMode.Survival);
        }
        public void StartRushGamePressed()
        {
            StartGame(GameMode.Rush);
        }

        private void StartGame(GameMode gameMode)
        {
            UseMenuContext().GameMode = gameMode;
            
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }

        private MenuContext UseMenuContext()
        {
            var context = FindFirstObjectByType<MenuContext>();

            if (context != null)
            {
                return context;
            }
            
            var go = new GameObject("MenuContext");
            context = go.AddComponent<MenuContext>();
            
            DontDestroyOnLoad(go);

            return context;
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
