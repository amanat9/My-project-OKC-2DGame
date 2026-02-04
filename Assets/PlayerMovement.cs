using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterController2D controller;

    // Start is called before the first frame update
    void Start()
    {

    }

    public Animator animator;

    private float horizontalMove = 0f;
    public float runSpeed = 40f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;



    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Start");
        //Debug.Log("Hello " + Input.GetAxisRaw("Horizontal"));
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        Flip();
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * runSpeed , rb.velocity.y);
    }
    private void Flip()
    {
        if (isFacingRight && horizontalMove < 0f || !isFacingRight && horizontalMove > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x = localScale.x * -1;
            transform.localScale = localScale; 
        }

    }


    public bool IsGrounded()
    {

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    
    }


}
