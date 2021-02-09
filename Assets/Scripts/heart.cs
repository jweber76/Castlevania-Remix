using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public GameObject player;
    public playerAttack playerAttack;
    //private Transform heartTransform;
    private Rigidbody2D heartRB;
    //private bool isGrounded;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAttack = player.GetComponent<playerAttack>();
        //heartTransform = GetComponent<Transform>();
        heartRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //potentially add Lerp movement back and forth on float down.
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
            {
                playerAttack.heartCounter += 1;
                Destroy(gameObject);
            }
            if (collision.CompareTag("Ground"))
        {
            heartRB.constraints = RigidbodyConstraints2D.FreezeAll;
            //isGrounded = true;
            Destroy(gameObject, 4f);
        }
    }
}
