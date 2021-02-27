using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitScreenButtons : MonoBehaviour
{
    public Button exitButton;
    public Button mainMenuButton;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        Frog.playerLives = 0;
        Score.CurrentScore = 0;
        SceneManager.LoadScene(0);
    }
}
