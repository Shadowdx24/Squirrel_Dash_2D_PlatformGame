using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Button levelBtn;
    [SerializeField] private string levelName;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(levelName) == (int) LevelState.Locked)
        {
            levelBtn.interactable = false;
        }
        else
        {
            levelBtn.interactable = true;
        }
    }
}
