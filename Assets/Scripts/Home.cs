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

    private void GameLevel()
    {
        LevelObj.SetActive(true);
    }
}
