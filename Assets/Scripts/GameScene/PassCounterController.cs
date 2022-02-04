using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCounterController : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameController.gameController.UpdateCounter();
    }
}
