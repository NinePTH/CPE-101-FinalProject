using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PLayerMovement : MonoBehaviour
{
    public float Speed = 5f;

    float horizontal;
    float vertical;

    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public Animator at;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //input
         horizontal = Input.GetAxis("Horizontal");
         vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //movement
        Vector2 movement = new Vector2(horizontal, vertical);
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);
        if (horizontal < 0)
        {
            sr.flipX = true;
        }
        else if (horizontal > 0)
        {
            sr.flipX = false;
        }
        at.SetBool("iswalking", movement.sqrMagnitude > 0);
    }
}
