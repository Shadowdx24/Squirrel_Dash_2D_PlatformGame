using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField] private GameObject LevelObj;
    public void GameStart()
    {
        // Start a Game
        GameLevel();
        //SceneManager.LoadScene(1);
       // AudioManager.instance.Play("Level 1");
       //AudioManager.instance.Stop("Home");
       //PlayerPrefs.SetInt("Health",3);
    }

    public void GameQuit()
    {
        // Quit a Game
        Application.Quit();
    }

    private void GameLevel()
    {
        LevelObj.SetActive(true);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
        AudioManager.instance.Play("Level 1");
        AudioManager.instance.Stop("Home");
        PlayerPrefs.SetInt("Health", 3);
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
        AudioManager.instance.Play("Level 2");
        AudioManager.instance.Stop("Home");
        PlayerPrefs.SetInt("Health", 3);
    }

    public void Level3()
    {
        SceneManager.LoadScene(3);
        AudioManager.instance.Play("Level 3");
        AudioManager.instance.Stop("Home");
        PlayerPrefs.SetInt("Health", 3);
    }

    public void Level4()
    {
        SceneManager.LoadScene(4);
        //AudioManager.instance.Play("Level 1");
        AudioManager.instance.Stop("Home");
        PlayerPrefs.SetInt("Health", 3);
    }
    public void Level5()
    {
        SceneManager.LoadScene(5);
        //AudioManager.instance.Play("Level 1");
        AudioManager.instance.Stop("Home");
        PlayerPrefs.SetInt("Health", 3);
    }
}
