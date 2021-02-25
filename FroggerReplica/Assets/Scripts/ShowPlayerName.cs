using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerName : MonoBehaviour
{
    public Text nameText;

    public void Start()
    {
        DisplayPlayerName();
    }

    public void DisplayPlayerName()
    {
        nameText.text = "Player: " + PlayerName.playerName;
    }
}
