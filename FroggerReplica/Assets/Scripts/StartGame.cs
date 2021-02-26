using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startGameBtn;

    public void EnterGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartFromExit()
    {
        Frog.playerLives = ChangeLives.livesAmount;
        Score.CurrentScore = 0;
        SceneManager.LoadScene(1);
    }
}
