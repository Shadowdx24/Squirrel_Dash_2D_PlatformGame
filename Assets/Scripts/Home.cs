using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public void GameStart()
    {
        // Start a Game
        SceneManager.LoadScene(1);
       // AudioManager.instance.Play("Level1 Bg");
        AudioManager.instance.Stop("Home");
    }

    public void GameQuit()
    {
        // Quit a Game
        Application.Quit();
    }
}
