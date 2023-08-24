using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void VolumeChange()
    {
        SoundManager.Instance.ChangeVol(slider);
    }
}
