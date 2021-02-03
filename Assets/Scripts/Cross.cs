using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour
{
    public Transform attackPoint;
    private Transform crossTransform;
    private Vector3 startPoint;
    private Vector3 targetPoint;
    public float speed;
    private bool isReturning = false;

    // Start is called before the first frame update
    void Start()
    {
        crossTransform = GetComponent<Transform>();
        crossTransform.position = attackPoint.position;
        startPoint = attackPoint.position;
        targetPoint = new Vector3((crossTransform.position.x + 10f), crossTransform.position.y, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        crossTransform.position = Vector3.MoveTowards(crossTransform.position, targetPoint, speed * Time.deltaTime);

       if(crossTransform.position == targetPoint)
        {
            targetPoint = startPoint;
            isReturning = true;
        }
       
       if(isReturning == true && crossTransform.position == startPoint)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
