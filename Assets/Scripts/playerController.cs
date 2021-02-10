using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D player;
    private CapsuleCollider2D playerCollider;
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
        playerTransform = GetComponent<Transform>();
        player = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }
    void FixedUpdate()
    {
        if (isGrounded == true && onStairs == false)
        {
            player.gravityScale = 1f;

            if (player.velocity.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (player.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            {
                if (Input.GetAxisRaw("Horizontal") == 0)
                {
                    player.velocity = Vector2.zero;
                }

                else
                {
                    float moveHorizontal = Input.GetAxisRaw("Horizontal");

                    Vector2 movement = new Vector2(moveHorizontal, 0);

                    player.velocity = movement * speed;
                    player.velocity = Vector2.ClampMagnitude(player.velocity, 5);
                }
                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    if (nearStairs == false || (nearStairs == true && (stairsFacing == stairsSlope)))
                    {
                        player.velocity = Vector2.zero;
                        playerCollider.offset = new Vector2(0, -0.5f);
                        playerCollider.size = new Vector2(1, 1);
                    }
                }

                else
                {
                    playerCollider.offset = new Vector2(0, 0);
                    playerCollider.size = new Vector2(1, 2);
                }
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    if (nearStairs == false || (nearStairs == true && (stairsFacing != stairsSlope)))
                    {
                        player.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    }
                }

                if (player.velocity.y == 0 && nearStairs == true)
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
        if (Input.GetAxisRaw("Vertical") > 0 && playerTransform.position.x != nearbyStairsTransform.position.x)
        {
            if (playerTransform.position.x < nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (playerTransform.position.x > nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            player.velocity = Vector2.zero;
            player.position = Vector2.MoveTowards(player.position, new Vector2(nearbyStairsTransform.position.x, player.position.y), stepRate * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") > 0 && playerTransform.position.x == nearbyStairsTransform.position.x)
        {
            stairsStartPoint = playerTransform.position;
            stairsEndPoint = stairsInfo.endPoint.transform.position;
            transform.localScale = new Vector3(1, 1, 1);
            onStairs = true;
            player.velocity = Vector2.zero;
        }
    }

    void ApproachingStairsEntranceFromLeftNegativeSlope()
    {
        if (Input.GetAxisRaw("Vertical") < 0 && playerTransform.position.x != nearbyStairsTransform.position.x)
        {
            if (playerTransform.position.x < nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (playerTransform.position.x > nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            player.velocity = Vector2.zero;
            player.position = Vector2.MoveTowards(player.position, new Vector2(nearbyStairsTransform.position.x, player.position.y), stepRate * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") < 0 && playerTransform.position.x == nearbyStairsTransform.position.x)
        {
            stairsStartPoint = playerTransform.position;
            stairsEndPoint = stairsInfo.endPoint.transform.position;
            transform.localScale = new Vector3(1, 1, 1);
            onStairs = true;
            player.velocity = Vector2.zero;
        }
    }
    void ApproachingStairsEntranceFromRightPositiveSlope()
    {
        if (Input.GetAxisRaw("Vertical") < 0 && playerTransform.position.x != nearbyStairsTransform.position.x)
        {
            if (playerTransform.position.x < nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (playerTransform.position.x > nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            player.velocity = Vector2.zero;
            player.position = Vector2.MoveTowards(player.position, new Vector2(nearbyStairsTransform.position.x, player.position.y), stepRate * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") < 0 && playerTransform.position.x == nearbyStairsTransform.position.x)
        {
            stairsStartPoint = playerTransform.position;
            stairsEndPoint = stairsInfo.endPoint.transform.position;
            transform.localScale = new Vector3(-1, 1, 1);
            onStairs = true;
            player.velocity = Vector2.zero;
        }
    }
    void ApproachingStairsEntranceFromRightNegativeSlope()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && playerTransform.position.x != nearbyStairsTransform.position.x)
        {
            if (playerTransform.position.x < nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (playerTransform.position.x > nearbyStairsTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            player.velocity = Vector2.zero;
            player.position = Vector2.MoveTowards(player.position, new Vector2(nearbyStairsTransform.position.x, player.position.y), stepRate * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") > 0 && playerTransform.position.x == nearbyStairsTransform.position.x)
        {
            stairsStartPoint = playerTransform.position;
            stairsEndPoint = stairsInfo.endPoint.transform.position;
            transform.localScale = new Vector3(-1, 1, 1);
            onStairs = true;
            player.velocity = Vector2.zero;
        }
    }

    void PositiveSlopeStairs()
    {
        if (onStairs == true)
        {
            player.gravityScale = 0f;
            if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                player.position = Vector2.MoveTowards(player.position, stairsEndPoint, stepRate * Time.deltaTime);
            }
            else if (Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                player.position = Vector2.MoveTowards(player.position, stairsStartPoint, stepRate * Time.deltaTime);
            }
        }
    }
    void NegativeSlopeStairs()
    {
        if (onStairs == true)
        {
            player.gravityScale = 0f;
            if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                player.position = Vector2.MoveTowards(player.position, stairsEndPoint, stepRate * Time.deltaTime);
            }
            else if (Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                player.position = Vector2.MoveTowards(player.position, stairsStartPoint, stepRate * Time.deltaTime);
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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player.gravityScale = 1;
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

