using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField] private GameObject LevelObj;
    [SerializeField] private GameObject SettingObj;

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

    public void GameSetting()
    {
        SettingObj.SetActive(true);
    }

    public void GameHome()
    {
        Time.timeScale = 1.0f;
        SettingObj.SetActive(false);
        
        //AudioManager.instance.Stop("Game Over");
        //AudioManager.instance.Play("Home");
    }
}
