using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int rate;

    private void Start()
    {
        int dice = Random.Range(0, 100);
        Debug.Log(dice);

        if(dice >= rate)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.soundManager.PlaySE(SoundManager.SE.ItemGet);
        GameController.gameController.UpdateCounter(5);
        Destroy(gameObject);
    }
}
