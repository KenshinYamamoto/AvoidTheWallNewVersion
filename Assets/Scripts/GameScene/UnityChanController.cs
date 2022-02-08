using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UnityÇøÇ·ÇÒÇä«óùÇ∑ÇÈ

public class UnityChanController : MonoBehaviour
{
    public float jumpPower = 600f;

    Animator animator;
    public Rigidbody2D rb2D;
    public bool gamePlay;

    public static UnityChanController unityChan;
    private void Awake()
    {
        unityChan = this;
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!gamePlay)
        {
            return;
        }

        rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        animator.SetFloat("Vertical", rb2D.velocity.y);

        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        animator.SetTrigger("Jump");
        rb2D.AddForce(Vector2.up * jumpPower);
        SoundManager.soundManager.PlaySE(SoundManager.SE.Jump1);
    }

    void Finish()
    {
        SoundManager.soundManager.PlaySE(SoundManager.SE.Finish);

        Invoke("ToTitle", 2.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gamePlay)
        {
            return;
        }

        if (collision.CompareTag("Coin"))
        {
            SoundManager.soundManager.PlaySE(SoundManager.SE.ItemGet);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gamePlay)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Ground"))
        {
            gamePlay = false;
            animator.SetTrigger("Damage");
            SoundManager.soundManager.PlaySE(SoundManager.SE.Damage);
            SoundManager.soundManager.PauseBGM();

            Invoke("Finish", 1f);
        }
    }

    public bool GamePlayFlag()
    {
        return gamePlay;
    }

    void ToTitle()
    {
        GameController.gameController.ToTitle();
    }
}
