using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public Transform primaryAttackPoint;
    public int attackLength;
    private Vector2 attackRange; //need to make this accessible to other script to increase whip range

    public Transform secondaryAttackPoint;
    public GameObject activeSubWeapon;
    public LayerMask destructableLayers;

    public float attackRate;
    private float nextAttackTime;
    void Update()
    {
        attackRange = new Vector2(attackLength, 0.6f);

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextAttackTime)
        {
            PrimaryAttack();
            nextAttackTime = nextAttackTime + attackRate * Time.deltaTime;
        }
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Time.time >= nextAttackTime)
        {
            SecondaryAttack();
            nextAttackTime = nextAttackTime + attackRate * Time.deltaTime;
        }
    }

    void PrimaryAttack()
    {
        //play animation

        //detect destructables
        Collider2D[] hitDestructables = Physics2D.OverlapBoxAll(primaryAttackPoint.position, attackRange, 0f, destructableLayers);

        //deal damage
        foreach(Collider2D enemy in hitDestructables)
        {
            Debug.Log("Hit " + enemy.name);
        }
    }

    void SecondaryAttack()
    {
        Instantiate(activeSubWeapon, secondaryAttackPoint.position, secondaryAttackPoint.rotation);
    }    
    
    void OnDrawGizmosSelected()
    {
        if (primaryAttackPoint == null)
            return;
            Gizmos.DrawWireCube(primaryAttackPoint.position, attackRange);   
    }
}
