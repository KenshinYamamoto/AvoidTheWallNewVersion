using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollObject : MonoBehaviour
{
    public float speed;
    public float startPosition;
    public float endPosition;
    Block block;

    private void Start()
    {
        block = GetComponent<Block>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "EndlessGameScene" && !UnityChanController.unityChan.GamePlayFlag())
        {
            return;
        }

        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        if(transform.position.x <= endPosition)
        {
            ScrollEnd();
        }
    }

    void ScrollEnd()
    {
        float diff = transform.position.x - endPosition;
        Vector3 restartPosition = transform.position;
        restartPosition.x = startPosition + diff;
        transform.position = restartPosition;
        if(block == null)
        {
            return;
        }
        block.ChangeHeight();
    }
}
