using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    
    private Animator playerAnimation;
    private Rigidbody2D rigidbody;
    private bool isFlipped = false;

    private float jumpForce = 200f;
    private float movementSmoothing = .001f;
    private Vector3 velocity = Vector3.zero;

    private int terrainLayerIndex = 0;

    private bool isGrounded = true;
    private bool jump = false;

    private float movement = 0.0f;
    public Vector3 respawnPoint;
 
    void Start()
    {
        playerAnimation = GetComponent<Animator>();

        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimation.Play("Idle", 0, 0.25f);
        respawnPoint = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            jump = true;
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement = -speed;
            if (!isFlipped)
            {
                flip();
            }
            playerAnimation.SetFloat("Speed", speed);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            movement = speed;
            if (isFlipped)
            {
                flip();
            }
            playerAnimation.SetFloat("Speed", speed);
        }
        else
        {
            movement = 0;
            playerAnimation.SetFloat("Speed", 0);
        }

        playerAnimation.SetBool("OnGround", isGrounded);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (terrainLayerIndex == col.gameObject.layer)
        {
            isGrounded = true;
        }
    }

    void FixedUpdate()
    {
        //float moveX = Input.GetAxis("Horizontal");

        //rigidbody.MovePosition(rigidbody.position + Vector2.right * moveX * speed * Time.deltaTime);

        if (movement != 0)
        {
            Vector3 targetVelocity = new Vector2(movement, rigidbody.velocity.y);
            rigidbody.velocity = 
                Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref velocity, movementSmoothing);
        }
        if (jump)
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    void flip()
    {
        isFlipped = !isFlipped;
        transform.localScale = new Vector3(transform.localScale.x * -1
            , transform.localScale.y, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "FallDetector") {
            transform.position = respawnPoint;
        }
        if (other.tag == "Checkpoint") {
            respawnPoint = other.transform.position;
        }
    }

    /*public float speed = 10f;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");

        rigidbody.MovePosition(rigidbody.position + Vector2.right * moveX * speed * Time.deltaTime);
    }

    //    Manipulations with physics should be written in void FixedUpdate()
    */
}
