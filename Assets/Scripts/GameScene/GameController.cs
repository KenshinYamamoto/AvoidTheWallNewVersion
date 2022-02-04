using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SceneName] public string nextScene;

    [SerializeField] GameObject countText;
    [SerializeField] Text PassCounterText;
    [SerializeField] UnityChanController unityChan;

    int counter = 0;

    public static GameController gameController;
    private void Awake()
    {
        gameController = this;
    }

    private void Start()
    {        
        unityChan.rb2D.gravityScale = 0;
        SoundManager.soundManager.PlayBGM(SoundManager.BGM.Game);
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        int count = 3;
        while (count != 0)
        {
            countText.GetComponent<Text>().text = count.ToString();
            switch (count)
            {
                case 1: SoundManager.soundManager.PlaySE(SoundManager.SE.One); break;
                case 2: SoundManager.soundManager.PlaySE(SoundManager.SE.Two); break;
                case 3: SoundManager.soundManager.PlaySE(SoundManager.SE.Three); break;
            }

            yield return new WaitForSeconds(1f);
            count--;
        }
        SoundManager.soundManager.PlaySE(SoundManager.SE.Start);
        countText.SetActive(false);
        unityChan.rb2D.gravityScale = 3.5f;
        unityChan.gamePlay = true;
    }

    public void ToTitle()
    {
        if(PlayerPrefs.GetInt("HighScore") < counter)
        {
            PlayerPrefs.SetInt("HighScore", counter);
        }

        SceneManager.LoadScene(nextScene);
    }

    public void UpdateCounter()
    {
        counter++;
        PassCounterText.text = "Score : " + counter;
    }
}
