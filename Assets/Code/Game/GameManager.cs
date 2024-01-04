using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
	public class GameManager : MonoBehaviour
	{
		public void LeaveGame()
		{
			SceneManager.LoadScene("MainMenuScene");
		}
	}
}