using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{

    [SerializeField] private Slider VolumeSlider;

    public void ChangeVolume()
    {
       AudioManager.instance.SetVolume(VolumeSlider.value);
    }
}
