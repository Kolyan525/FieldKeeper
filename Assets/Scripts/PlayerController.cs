using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

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
    

    
}
