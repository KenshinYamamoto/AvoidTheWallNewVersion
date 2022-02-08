using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// タイトルシーンを管理する

public class TitleController : MonoBehaviour
{
    [SceneName]
    public string gameScene;

    [SerializeField] GameObject titleCanvas;
    [SerializeField] GameObject optionCanvas;

    [SerializeField] Toggle MuteBGMYesToggle;
    [SerializeField] Toggle MuteSEYesToggle;

    [SerializeField] Text highScoreText;

    int muteBGM; // 0なら再生、1ならミュートする
    int muteSE;  // 0なら再生、1ならミュートする

    public static TitleController titleController;
    private void Awake()
    {
        titleController = this;
    }

    private void Start()
    {
        SoundManager.soundManager.PlayBGM(SoundManager.BGM.Title);
        ShowCanvas(true, false);
        highScoreText.text = "HIGH SCORE : " + PlayerPrefs.GetInt("HighScore");
        muteBGM = PlayerPrefs.GetInt("MuteBGM");
        muteSE = PlayerPrefs.GetInt("MuteSE");

        switch (muteBGM)
        {
            case 0:
                MuteBGMYesToggle.isOn = false;
                break;
            case 1:
                MuteBGMYesToggle.isOn = true;
                break;
        }

        switch (muteSE)
        {
            case 0:
                MuteSEYesToggle.isOn = false;
                break;
            case 1:
                MuteSEYesToggle.isOn = true;                
                break;
        }
    }

    public void ToGame()
    {
        SoundManager.soundManager.PlaySE(SoundManager.SE.DecisionButton);
        SceneManager.LoadScene(gameScene);
    }
    void ShowCanvas(bool titleCanvasActive,bool optionCanvasActive)
    {
        titleCanvas.SetActive(titleCanvasActive);
        optionCanvas.SetActive(optionCanvasActive);
    }

    public void ToOption()
    {
        SoundManager.soundManager.PlaySE(SoundManager.SE.DecisionButton);
        ShowCanvas(false, true);
    }

    public void BackButton()
    {
        SoundManager.soundManager.PlaySE(SoundManager.SE.BackButton);

        if (MuteBGMYesToggle.isOn)
        {
            PlayerPrefs.SetInt("MuteBGM", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MuteBGM", 0);
        }

        if (MuteSEYesToggle.isOn)
        {
            PlayerPrefs.SetInt("MuteSE", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MuteSE", 0);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool MuteBGMFlag()
    {
        return MuteBGMYesToggle.isOn;
    }

    public bool MuteSEFlag()
    {
        return MuteSEYesToggle.isOn;
    }
}
