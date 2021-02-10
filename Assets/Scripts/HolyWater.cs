using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWater : MonoBehaviour
{
    private Rigidbody2D holyWater;
    public Rigidbody2D player;
    public float throwForce;

    // Start is called before the first frame update
    void Start()
    {
        holyWater = GetComponent<Rigidbody2D>();
        holyWater.AddForce(new Vector2((player.velocity.x + 4f), throwForce), ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
    if(collision.gameObject.CompareTag("Ground"))
        {
            //filler water explosion
            Destroy(gameObject);
        }
    }
}
