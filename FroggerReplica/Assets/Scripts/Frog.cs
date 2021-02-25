using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;
    public static int playerLives = 3;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.MovePosition(rb.position + Vector2.right);
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.MovePosition(rb.position + Vector2.left);
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.MovePosition(rb.position + Vector2.up);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position + Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
        
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Car")
        {
            Debug.Log("We Lost!");
            if (Score.CurrentScore > Score.MaxScore)
            {
                Score.MaxScore = Score.CurrentScore;
            }
            Score.CurrentScore = 0;
            playerLives--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (playerLives <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
