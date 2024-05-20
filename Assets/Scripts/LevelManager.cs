using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private Button[] LevelBtn;
    [SerializeField] private string[] LevelName;
    private int currLevel = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }    
    }

    void Start()
    {
        UnlockFirstLevel();
    }

   private void UnlockFirstLevel()
    {
        PlayerPrefs.SetInt(LevelName[0], (int)LevelState.Unlocked);
    }

    public void UnlockNextLevel()
    {
        LevelMark(currLevel);
        currLevel++;
        PlayerPrefs.SetInt(LevelName[currLevel], (int)LevelState.Unlocked);
    }

    private void LevelMark(int lel)
    {
        PlayerPrefs.SetInt(LevelName[lel], (int)LevelState.Completed);
    }

    private void LevelReset()
    {
        currLevel--;
        PlayerPrefs.SetInt(LevelName[currLevel], (int)LevelState.Locked);
    }
}
