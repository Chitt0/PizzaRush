using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movSpaceInvaders : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movPlayer;
    public float speed, balaSpeed;
    public Transform spawnBala;
    public GameObject bala;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movPlayer = new Vector2(Input.GetAxis("Horizontal"), 0);
        rb.velocity = movPlayer * speed;

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject b = Instantiate(bala, spawnBala.position, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().AddForce(Vector2.up * balaSpeed, ForceMode2D.Impulse);
            Destroy(b, 2f);
            animator.SetTrigger("TomassoThrow");
        }

        if (movPlayer.x != 0)
        {
            animator.SetBool("TomassoRight", true);
            if (movPlayer.x > 0)
            {
                transform.localScale = new Vector2(0.9563f, transform.localScale.y);

            }
            else if (movPlayer.x < 0) 
            {
                transform.localScale = new Vector2(-0.9563f, transform.localScale.y);
            }
        }
        else 
        {
            animator.SetBool("TomassoRight", false);
        }
    }
}
