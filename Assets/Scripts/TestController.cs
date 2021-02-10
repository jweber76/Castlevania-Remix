using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    private Transform testerTransform;
    private Rigidbody2D tester;
    private CircleCollider2D testerCollider;
    public float jumpForce;
    public bool nearStairs = false;
    public GameObject nearbyStairs;
    public Transform nearbyStairsTransform;
    public StairsInfo stairsInfo;
    public Vector2 stairsStartPoint;
    public Vector2 stairsEndPoint;
    public int stairsFacing;
    public int stairsSlope;
    public float maxVelocity;
    private float speed = 5f;
    public float nextStepTime;
    public float stepRate = 4f;
    public bool onStairs = false;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        testerTransform = GetComponent<Transform>();
        tester = GetComponent<Rigidbody2D>();
        testerCollider = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        if (isGrounded == true && onStairs == false)
        {
            tester.gravityScale = 1f;
            
            if (tester.velocity.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (tester.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            {
                if (Input.GetAxisRaw("Horizontal") == 0)
                {
                    tester.velocity = Vector2.zero;
                }

                else
                {
                    float moveHorizontal = Input.GetAxisRaw("Horizontal");

                    Vector2 movement = new Vector2(moveHorizontal, 0);

                    tester.velocity = movement * speed;
                    tester.velocity = Vector2.ClampMagnitude(tester.velocity, 5);
                }
                if (Input.GetAxisRaw("Vertical") < 0 && stairsFacing == stairsSlope)
                {
                    tester.velocity = Vector2.zero;
                    testerCollider.offset = new Vector2(0, -0.5f);
                    //testerCollider.size = new Vector2(1, 1);
                }

                else
                {
                    testerCollider.offset = new Vector2(0, 0);
                    //testerCollider.size = new Vector2(1, 2);
                }
                if (Input.GetAxisRaw("Vertical") > 0 && stairsFacing != stairsSlope)
                {
                    tester.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                }

                if (tester.velocity.y == 0 && nearStairs == true)
                {
                    if (stairsFacing == 1 && stairsSlope == 1)
                    {
                        ApproachingStairsEntranceFromLeftPositiveSlope();
                    }
                    else if (stairsFacing == 1 && stairsSlope == -1)
                    {
                        ApproachingStairsEntranceFromLeftNegativeSlope();
                    }
                    else if (stairsFacing == -1 && stairsSlope == -1)
                    {
                        ApproachingStairsEntranceFromRightNegativeSlope();
                    }
                    else if (stairsFacing == -1 && stairsSlope == 1)
                    {
                        ApproachingStairsEntranceFromRightPositiveSlope();
                    }
                }
            }
        }

        if (onStairs == true)
        {
            if (stairsSlope == 1)
            {
                PositiveSlopeStairs();
            }
            else if (stairsSlope == -1)
            {
                NegativeSlopeStairs();
            }
        }
    }

    void ApproachingStairsEntranceFromLeftPositiveSlope()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && testerTransform.position.x != nearbyStairsTransform.position.x)
        {
            if (testerTransform.position.x < nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (testerTransform.position.x > nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            tester.velocity = Vector2.zero;
            tester.position = Vector2.MoveTowards(tester.position, new Vector2 (nearbyStairsTransform.position.x, tester.position.y), stepRate * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") > 0 && testerTransform.position.x == nearbyStairsTransform.position.x)
        {
            stairsStartPoint = testerTransform.position;
            stairsEndPoint = stairsInfo.endPoint.transform.position;
            transform.localScale = new Vector3(1, 1, 1);
            onStairs = true;
            tester.velocity = Vector2.zero;
        }
    }

    void ApproachingStairsEntranceFromLeftNegativeSlope()
    {
        if (Input.GetAxisRaw("Vertical") < 0 && testerTransform.position.x != nearbyStairsTransform.position.x)
        {
            if (testerTransform.position.x < nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (testerTransform.position.x > nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            tester.velocity = Vector2.zero;
            tester.position = Vector2.MoveTowards(tester.position, new Vector2(nearbyStairsTransform.position.x, tester.position.y), stepRate * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") < 0 && testerTransform.position.x == nearbyStairsTransform.position.x)
        {
            stairsStartPoint = testerTransform.position;
            stairsEndPoint = stairsInfo.endPoint.transform.position;
            transform.localScale = new Vector3(1, 1, 1);
            onStairs = true;
            tester.velocity = Vector2.zero;
        }
    }

    void ApproachingStairsEntranceFromRightPositiveSlope()
    {
        if (Input.GetAxisRaw("Vertical") < 0 && testerTransform.position.x != nearbyStairsTransform.position.x)
        {
            if (testerTransform.position.x < nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (testerTransform.position.x > nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            tester.velocity = Vector2.zero;
            tester.position = Vector2.MoveTowards(tester.position, new Vector2(nearbyStairsTransform.position.x, tester.position.y), stepRate * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") < 0 && testerTransform.position.x == nearbyStairsTransform.position.x)
        {
            stairsStartPoint = testerTransform.position;
            stairsEndPoint = stairsInfo.endPoint.transform.position;
            transform.localScale = new Vector3(-1, 1, 1);
            onStairs = true;
            tester.velocity = Vector2.zero;
        }
    }

    void ApproachingStairsEntranceFromRightNegativeSlope()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && testerTransform.position.x != nearbyStairsTransform.position.x)
        {
            if (testerTransform.position.x < nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (testerTransform.position.x > nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            tester.velocity = Vector2.zero;
            tester.position = Vector2.MoveTowards(tester.position, new Vector2(nearbyStairsTransform.position.x, tester.position.y), stepRate * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") > 0 && testerTransform.position.x == nearbyStairsTransform.position.x)
        {
            stairsStartPoint = testerTransform.position;
            stairsEndPoint = stairsInfo.endPoint.transform.position;
            transform.localScale = new Vector3(-1, 1, 1);
            onStairs = true;
            tester.velocity = Vector2.zero;
        }
    }

    void PositiveSlopeStairs()
    {
        if (onStairs == true)
        {
            tester.gravityScale = 0f;
            if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                tester.position = Vector2.MoveTowards(tester.position, stairsEndPoint, stepRate * Time.deltaTime);
            }
            else if (Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                tester.position = Vector2.MoveTowards(tester.position, stairsStartPoint, stepRate * Time.deltaTime);
            }
        }
    }

    void NegativeSlopeStairs()
    {
        if (onStairs == true)
        {
            tester.gravityScale = 0f;
            if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                tester.position = Vector2.MoveTowards(tester.position, stairsEndPoint, stepRate * Time.deltaTime);
            }
            else if (Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                tester.position = Vector2.MoveTowards(tester.position, stairsStartPoint, stepRate * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stairs"))
        {
            nearStairs = true;
            nearbyStairs = collision.gameObject;
            stairsInfo = nearbyStairs.GetComponent<StairsInfo>();
            nearbyStairsTransform = nearbyStairs.GetComponent<Transform>();
            stairsFacing = stairsInfo.facing;
            stairsSlope = stairsInfo.slope;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        nearStairs = !nearStairs;
        nearbyStairs = null;
        stairsInfo = null;
        nearbyStairsTransform = null;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            tester.gravityScale = 1;
            isGrounded = true;
            onStairs = false;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
