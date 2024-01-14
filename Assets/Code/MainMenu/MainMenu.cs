using Leaderboard;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public static MainMenu Instance { get; private set; } = default;

        [SerializeField] private LazyWindow<LeaderboardWindow> leaderboardWindow = default;
        [SerializeField] private CanvasGroup homeCanvasGroup = default;
        [SerializeField] private Transform windowContainer = null;

        public Transform WindowContainer => windowContainer;

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
            leaderboardWindow.Value.Open();

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
