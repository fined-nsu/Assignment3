using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Text livesRemainingText;

    // Start is called before the first frame update
    void Start()
    {
        livesRemainingText.text = "Remaining Lives: " + Frog.playerLives.ToString();
    }
}
