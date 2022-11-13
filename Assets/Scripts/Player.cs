using Beans2022;
using Beans2022.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    [SerializeField] Animator animator;

    [SerializeField] float jumpHeight;
    [SerializeField] float gravityScale;
    [SerializeField] float gravityScaleFalling;
    [SerializeField] float buttonTime = 0.5f;
    [SerializeField] float cancelRate = 100;
    [SerializeField] float checkGroundedOffset = 0.2f;

    Rigidbody rb;

    bool isJumping;
    bool jumpCancelled;

    float jumpTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isJumping && jumpCancelled && rb.velocity.y > 0)
        {
            rb.AddForce(Vector3.down * cancelRate);
        }
        if (rb.velocity.y > 0)
            rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        else
            rb.AddForce(Physics.gravity * (gravityScaleFalling - 1) * rb.mass);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            
            jumpCancelled = false;
            if (isGrounded())
            {
                jumpTime = 0;
                Jump();
            }
        }
        if (isJumping)
        {
            jumpTime += Time.deltaTime;
            if (isJumping && Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
                animator.SetBool("jumpCancelled", true);
            }
            if (jumpTime > buttonTime)
            {
                isJumping = false;
            }
        }
        if (!isJumping && isGrounded())
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("jumpCancelled", false);
            animator.SetBool("isFalling", false);
        }
        if(rb.velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
        }


    }

    void Jump()
    {
        animator.SetBool("isJumping", true);
        GameManager.Instance.GetComponent<AudioManager>().PlayJump();
        float jumpForce = Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y * gravityScale);
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    bool isGrounded()
    {
        Vector3 point = transform.position + Vector3.down * checkGroundedOffset;
        Vector3 size = new Vector3(transform.localScale.x, transform.localScale.y);
        bool grounded = false;
        foreach (Collider c in Physics.OverlapBox(point, size)){
            if(c.gameObject != this.gameObject)
            {
                grounded = true;
                break;
            }
        }

        return grounded;
    }
}
