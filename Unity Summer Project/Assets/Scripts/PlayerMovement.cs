using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private float xInput;
    private Rigidbody2D rb;
    private Animator animator;
    private float lastXInput;
    private bool isGrounded = false;
    [SerializeField] private BoxCollider2D feetCollider;
    [SerializeField] private float jumpForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastXInput = 1;
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        SetAnimation();

        isGrounded = CheckIfGrounded();
        if(isGrounded && Input.GetKeyDown(KeyCode.LeftControl))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
    }
    private bool CheckIfGrounded()
    {
        return Physics2D.BoxCast(feetCollider.bounds.center, feetCollider.bounds.size, 0f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
    }
    private void SetAnimation()
    {
        animator.SetBool("isRunning", xInput != 0);
        //Flip sprite when changing direction
        if (xInput != 0)
        {
            transform.localScale = new Vector3(xInput*10, 10, 0);
            lastXInput = xInput;
        }
        else
        {
            transform.localScale = new Vector3(lastXInput*10, 10, 0);
        }
    }
}
