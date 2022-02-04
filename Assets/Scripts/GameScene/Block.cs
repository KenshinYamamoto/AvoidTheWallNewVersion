using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public GameObject root;

    private void Start()
    {
        ChangeHeight();
    }

    public void ChangeHeight()
    {
        if (!UnityChanController.unityChan.GamePlayFlag())
        {
            return;
        }

        float height = Random.Range(minHeight, maxHeight);
        root.transform.localPosition = new Vector3(0, height, 0);
    }
}
