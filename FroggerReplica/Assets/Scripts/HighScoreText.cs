using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{
    public Text highScoreText;

    public void Start()
    {
        highScoreText.text = "Your high score was " + Score.MaxScore.ToString();
    }
}
