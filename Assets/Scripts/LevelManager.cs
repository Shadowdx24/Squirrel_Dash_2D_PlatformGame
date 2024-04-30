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

    // Start is called before the first frame update
    void Start()
    {
        UnlockFirstLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void UnlockFirstLevel()
    {
        PlayerPrefs.SetInt(LevelName[0], 1);
    }

    public void UnlockNextLevel()
    {
        currLevel++;
        PlayerPrefs.SetInt(LevelName[currLevel],1);
    }
}