using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource BGMAudioSource;
    [SerializeField] AudioSource SEAudioSource;

    [SerializeField] AudioClip[] BGMAudioClips;
    [SerializeField] AudioClip[] SEAudioClips;

    public enum BGM
    {
        Title,
        Game
    }

    public enum SE
    {
        ItemGet,
        Jump1,
        Jump2,
        Damage,
        Clear
    }

    public static SoundManager soundManager;
    private void Awake()
    {
        if(soundManager == null)
        {
            soundManager = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGM bgm)
    {
        int index = (int)bgm;
        BGMAudioSource.clip = BGMAudioClips[index];
        BGMAudioSource.Play();
    }

    public void PlaySE(SE se)
    {
        int index = (int)se;
        SEAudioSource.PlayOneShot(SEAudioClips[index]);
    }
}
