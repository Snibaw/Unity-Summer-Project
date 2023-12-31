using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    private Vector2 direction;
    private bool isGrounded;
    private Rigidbody2D rb;
    public float speed = 5f;
    private EnemyHealth enemyHealth;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        Debug.Log(player.position.x + " " + transform.position.x);
        direction = transform.position.x > player.position.x ? Vector2.left : Vector2.right;

        rb = GetComponent<Rigidbody2D>();
        enemyHealth = GetComponent<EnemyHealth>();
        FlipSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth.isDead) return;
        


        isGrounded = CheckIfGrounded();
        if(isGrounded)
        {
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        }
        else
        {
            direction = new Vector2(direction.x * -1, direction.y);
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
            FlipSprite();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            direction = new Vector2(direction.x * -1, direction.y);
            FlipSprite();
        }
    }


    private bool CheckIfGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
    }
    private void FlipSprite()
    {
        if(direction.x > 0)
        {
            transform.localScale = new Vector3(10, 10, 10);
        }
        else
        {
            transform.localScale = new Vector3(-10, 10, 10);
        }
    }
}
