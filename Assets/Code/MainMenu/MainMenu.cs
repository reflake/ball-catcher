using System;
using Cysharp.Threading.Tasks;
using Game;
using Game.Enum;
using Leaderboard;
using MainMenu.Dialog;
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

        public void OpenLeaderboard()
        {
            windowManager.Open<LeaderboardWindow>();
        }

        public void ExitPressed()
        {
            UniTask.Void(async () =>
            {
                var dialog = windowManager.Open<DialogWindow>();
                var description = "Are you sure?";
                var options = new[]
                {
                    (DialogResult.Ok, "Yes"),
                    (DialogResult.Cancel, "No")
                };
            
                var answer = await dialog.ShowDialogAsync(description, options, DialogResult.Cancel);
            
                if (answer == DialogResult.Ok)
                {
#if UNITY_EDITOR
                    EditorApplication.ExitPlaymode();
#else
                    Application.Quit();
#endif
                }
            });
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
    }
}
