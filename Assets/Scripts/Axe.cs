using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private Rigidbody2D axe;
    public Rigidbody2D player;
    public float throwForce;

    // Start is called before the first frame update
    void Start()
    {
        axe = GetComponent<Rigidbody2D>();
        axe.AddForce(new Vector2((player.velocity.x + 2f), throwForce), ForceMode2D.Impulse);
    }
        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //deal damage
        }
    }  
}
