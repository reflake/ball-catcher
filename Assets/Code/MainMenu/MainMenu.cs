using Leaderboard;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public static MainMenu Instance { get; private set; } = default;

        [SerializeField] private WindowManager windowManager = default;
        [SerializeField] private CanvasGroup homeCanvasGroup = default;
        [SerializeField] private Transform windowContainer = null;

        private void Awake()
        {
            Instance = this;
        }

        public void StartGamePressed()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void OpenLeaderboard()
        {
            windowManager.Open<LeaderboardWindow>();
            
            homeCanvasGroup.alpha = 0f;
            homeCanvasGroup.blocksRaycasts = false;
        }
        
        public void ExitPressed()
        {
            #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
            #else
            Application.Quit();
            #endif
        }

        public void BackHome()
        {
            homeCanvasGroup.alpha = 1f;
            homeCanvasGroup.blocksRaycasts = true;
        }
    }
}
