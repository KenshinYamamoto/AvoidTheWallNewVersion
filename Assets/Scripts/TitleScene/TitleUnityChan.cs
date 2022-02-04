using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUnityChan : MonoBehaviour
{
    public float jumpPower;

    Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Jump());
    }

    private void Update()
    {
        if(transform.position.y < 3f)
        {
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        while (transform.position.y < 3f)
        {
            Debug.Log("call");
            yield return new WaitForSeconds(0.5f);
            rb2D.AddForce(Vector2.up * jumpPower);
        }
    }
}
