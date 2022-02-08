using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCounterController : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        SoundManager.soundManager.PlaySE(SoundManager.SE.ItemGet);
        GameController.gameController.UpdateCounter(1);
    }
}
