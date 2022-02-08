using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ÉTÉEÉìÉhä÷åWÇä«óùÇ∑ÇÈ

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

    GameObject titleController;

    public static SoundManager soundManager;
    private void Awake()
    {
        if (soundManager == null)
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
        playSE = true;

        SearchObject();
    }

    private void Update()
    {
        if (!CheckIsExists())
        {
            return;
        }

        if (TitleController.titleController.MuteBGMFlag())
        {
            playBGM = false;
            PauseBGM();
        }
        else
        {
            playBGM = true;
            UnPauseBGM();
        }

        if (TitleController.titleController.MuteSEFlag())
        {
            playSE = false;
        }
        else
        {
            playSE = true;
        }
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
        if (!playSE)
        {
            return;
        }

        int index = (int)se;
        SEAudioSource.PlayOneShot(SEAudioClips[index]);
    }

    public void PauseBGM()
    {
        BGMAudioSource.Pause();
    }

    public void UnPauseBGM()
    {
        BGMAudioSource.UnPause();
    }

    public bool CheckIsExists()
    {
        if (titleController)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void SearchObject()
    {
        titleController = GameObject.Find("TitleController");
    }
}
