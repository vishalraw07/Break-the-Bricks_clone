using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    [SerializeField] private AudioSource soundFX;
    [SerializeField] private AudioSource soundBG;

    [SerializeField] private Sounds[] sounds;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }

    public void ChangeVol(Slider slider)
    {
        AudioListener.volume = slider.value;
    }

    public void PlayBG(SoundType sound)
    {
        AudioClip clip = getAudioClip(sound);
        soundBG.clip = clip;
        soundBG.volume = getVolume(sound);
        soundBG.Play();
    }

    public void PlayFX(SoundType sound)
    {
        AudioClip clip = getAudioClip(sound);
        soundFX.clip = clip;
        soundFX.volume = getVolume(sound);
        soundFX.Play();
    }

    private float getVolume(SoundType soundType)
    {
        Sounds sound = Array.Find(sounds, item => item.type == soundType);
        return sound.volume;
    }

    private AudioClip getAudioClip(SoundType soundType)
    {
        Sounds sound = Array.Find(sounds, item => item.type == soundType);
        return sound.clip;
    }
}

[Serializable]
public class Sounds
{
    public AudioClip clip;
    public SoundType type;
    [Range(0f, 1f)]
    public float volume = 0.3f;
}
public enum SoundType
{
    LobbyMusic,
    ButtonClick,
    Brick_1_Hit,
    Brick_1_Destroy,
    Brick_2_Destroy,
    Brick_3_Destroy
}


