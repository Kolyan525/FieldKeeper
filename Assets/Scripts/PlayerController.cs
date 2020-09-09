using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody;

    public float speed = 10f;

    void Start()
    {
        animator = GetComponent<Animator>();

        rigidbody = GetComponent<Rigidbody2D>();
        animator.Play("Idle", 0, 0.25f);
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");

        rigidbody.MovePosition(rigidbody.position + Vector2.right * moveX * speed * Time.deltaTime);
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
