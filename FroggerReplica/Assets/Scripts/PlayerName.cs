using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public static string playerName;
    public InputField getNameInput;

    public void GetPlayerName()
    {
        playerName = getNameInput.text;
    }
}
