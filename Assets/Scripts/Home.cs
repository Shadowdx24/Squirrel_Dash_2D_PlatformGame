using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public void GameStart()
    {
        // Start a Game
        SceneManager.LoadScene(1);
        AudioManager.instance.Play("Level 1");
        AudioManager.instance.Stop("Home");
        PlayerPrefs.SetInt("Health",3);
    }

    public void GameQuit()
    {
        // Quit a Game
        Application.Quit();
    }
}
