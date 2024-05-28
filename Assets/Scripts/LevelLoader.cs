using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Button levelBtn;
    [SerializeField] private string levelName;

    void Start()
    {
        if (PlayerPrefs.GetInt(levelName) == (int)LevelState.Locked)
        {
            levelBtn.interactable = false;
        }
        else
        {
            levelBtn.interactable = true;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
        AudioManager.instance.Stop("Home");
        AudioManager.instance.Play(levelName);
    }
}
