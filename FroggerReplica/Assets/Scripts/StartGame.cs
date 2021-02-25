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
}
