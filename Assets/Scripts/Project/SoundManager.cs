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
        Clear,
        Finish,
        One,
        Two,
        Three,
        Start,
        DecisionButton,
        BackButton
    }

    public bool playBGM;
    public bool playSE;

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

    private void Start()
    {
        playBGM = true;
    }

    public void PlayBGM(BGM bgm)
    {
        if (!playBGM)
        {
            return;
        }

        int index = (int)bgm;
        BGMAudioSource.clip = BGMAudioClips[index];
        BGMAudioSource.Play();
    }

    public void PlaySE(SE se)
    {
        int index = (int)se;
        SEAudioSource.PlayOneShot(SEAudioClips[index]);
    }

    public void StopBGM()
    {
        BGMAudioSource.Stop();
    }
}
