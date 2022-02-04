using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SceneName]
    public string gameScene;
    [SceneName]
    public string optionScene;

    [SerializeField] Text highScoreText;

    public static TitleController titleController;
    private void Awake()
    {
        titleController = this;
    }

    private void Start()
    {
        SoundManager.soundManager.PlayBGM(SoundManager.BGM.Title);

        highScoreText.text = "HIGH SCORE : " + PlayerPrefs.GetInt("HighScore");
    }

    public void ToGameScene()
    {
        SoundManager.soundManager.PlaySE(SoundManager.SE.DecisionButton);
        SceneManager.LoadScene(gameScene);
    }

    public void ToOptionScene()
    {
        SoundManager.soundManager.PlaySE(SoundManager.SE.DecisionButton);
        SceneManager.LoadScene(optionScene);
    }
}
