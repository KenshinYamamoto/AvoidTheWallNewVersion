using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    [SceneName] public string nextScene;

    [SerializeField] Toggle muteBGMToggle;
    int BGMMute = 0;

    private void Start()
    {
        BGMMute = PlayerPrefs.GetInt("MuteBGM");
        switch (BGMMute)
        {
            case 0:
                muteBGMToggle.isOn = false;
                break;
            case 1:
                muteBGMToggle.isOn = true;
                break;
        }
        SoundManager.soundManager.StopBGM();
    }

    public void muteBGM()
    {
        if (!muteBGMToggle.isOn)
        {
            BGMMute = 0;
            SoundManager.soundManager.playBGM = true;
        }
        else
        {
            BGMMute = 1;
            SoundManager.soundManager.playBGM = false;
        }
        PlayerPrefs.SetInt("MuteBGM", BGMMute);
    }

    public void ToTitle()
    {
        SceneManager.LoadScene(nextScene);
    }
}
