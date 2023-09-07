using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    private Animator animator;
    public Vector2 direction;

    private void Start() {
        animator = GetComponent<Animator>();
        Destroy(gameObject, 2f);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            animator.SetTrigger("hit");
            Destroy(gameObject, 0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
