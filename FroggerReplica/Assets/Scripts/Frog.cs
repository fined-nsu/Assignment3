using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;
    public static int playerLives = 3;
    public Button saveButton;
    public Button loadButton;
    public Button saveAsJSON;
    public AudioClip frogHop;
    public AudioSource audioSource;

    void Update()
    {
        audioSource.enabled = PauseMenu.soundToggleValue;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.MovePosition(rb.position + Vector2.right);
            audioSource.Play();
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.MovePosition(rb.position + Vector2.left);
            audioSource.Play();
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.MovePosition(rb.position + Vector2.up);
            audioSource.Play();
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position + Vector2.down);
            audioSource.Play();
        }
        WinGame();
    }

    void OnTriggerEnter2D(Collider2D col)
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

    void WinGame()
    {
        if (Score.CurrentScore > 600)
        {
            SceneManager.LoadScene(3);
        }
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        //int i = 0;
        /*foreach (GameObject targetGameObject in targets)
        {
            Target target = targetGameObject.GetComponent<Target>();
            if (target.activeRobot != null)
            {
                save.livingTargetPositions.Add(target.position);
                save.livingTargetsTypes.Add((int)target.activeRobot.GetComponent<Robot>().type);
                i++;
            }
        }*/
        //save.frogPosition = new Vector2(rb.transform.position.x, rb.transform.position.y);
        save.lives = playerLives;
        save.score = Score.CurrentScore;

        return save;
    }

    public void SaveGame()
    {
        // 1
        Save save = CreateSaveGameObject();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
    }

    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }


    public void LoadGame()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            // 3
            /*for (int i = 0; i < save.livingTargetPositions.Count; i++)
            {
                int position = save.livingTargetPositions[i];
                Target target = targets[position].GetComponent<Target>();
                target.ActivateRobot((RobotTypes)save.livingTargetsTypes[i]);
                target.GetComponent<Target>().ResetDeathTimer();
            }*/

            // 4
            playerLives = save.lives;
            Score.CurrentScore = save.score;
            //rb.transform.position = new Vector2(save.frogPosition.x,save.frogPosition.y);

            Debug.Log("Game Loaded");
            Time.timeScale = 1;
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}