using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 2;
    public bool isDead = false;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private void Start() {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;

        boxCollider.enabled = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
        animator.SetTrigger("Die");
        Destroy(gameObject,1f);
    }
}
