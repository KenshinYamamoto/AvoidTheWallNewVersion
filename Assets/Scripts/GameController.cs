using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    private void Awake()
    {
        gameController = this;
    }

    private void Start()
    {
        SoundManager.soundManager.PlayBGM(SoundManager.BGM.Game);
    }
}
