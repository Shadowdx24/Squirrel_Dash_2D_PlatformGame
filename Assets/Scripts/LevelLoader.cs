using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Button levelBtn;
    [SerializeField] private string levelName;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(levelName)==1)
        {
            levelBtn.interactable = true;
        }
        else
        {
            levelBtn.interactable = false;
        }
    }
}
