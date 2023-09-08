using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    private Animator animator;
    public Vector2 direction;
    public string targetTag = "Enemy";
    private bool isDead = false;

    private void Start() {
        animator = GetComponent<Animator>();
        direction = Vector2.right;
        Destroy(gameObject, 2f);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(targetTag))
        {
            if(isDead) return;
            isDead = true;
            if(targetTag == "Enemy")
            {
                animator.SetTrigger("hit");
                other.GetComponent<EnemyHealth>().TakeDamage(1);
                Destroy(gameObject, 0.2f);
            }
            else
            {
                other.GetComponent<PlayerHealth>().TakeDamage(1);
                Destroy(gameObject);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) return;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
