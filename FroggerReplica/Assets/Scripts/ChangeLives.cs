using UnityEngine;
using UnityEngine.UI;

public class ChangeLives : MonoBehaviour
{
    public Dropdown livesDropdown;
    public void SetLives()
    {
        if (livesDropdown.value == 1)
        {
            Frog.playerLives = 1;
        }
        else if (livesDropdown.value == 2)
        {
            Frog.playerLives = 2;
        }
        else if (livesDropdown.value == 3)
        {
            Frog.playerLives = 4;
        }
        else if(livesDropdown.value == 4)
        {
            Frog.playerLives = 5;
        }
        else
        {
            Frog.playerLives = 3;
        }
    }
}
