using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public Rigidbody2D flyingEnemy;
    public Transform flyingEnemyTransform;
    public int flyingEnemyHealth = 1;
    public GameObject player;
    public playerAttack playerAttack;
    public GameObject enemyDrop;
    public float facing;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAttack = player.GetComponent<playerAttack>();
        flyingEnemyTransform = GetComponent<Transform>();
        flyingEnemy = GetComponent<Rigidbody2D>();
        facing = flyingEnemyTransform.localScale.x;
    }

    void FixedUpdate()
    {
        if (flyingEnemyHealth <= 0)
        {
            //Instantiate(enemyDrop, flyingEnemy.position, flyingEnemy.rotation);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int attackDamage)
    {
        flyingEnemyHealth -= playerAttack.attackDamage;
    }
    void OnBecameVisible()
    {
        gameObject.SetActive(true);
        flyingEnemy.velocity = new Vector2(facing * speed, 0);
    }
    void OnBecameInvisible()
    {
        {
            Destroy(gameObject, 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            flyingEnemyHealth -= 1;
        }
    }
}
