using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform barrel;
    [SerializeField] private float reloadTime = 1.5f;
    private float reloadTimer;
    private EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        reloadTimer = reloadTime;
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth.isDead) return;
        
        reloadTimer -= Time.deltaTime;
        if (reloadTimer < 0)
        {
            float zRotation = transform.localScale.x > 0 ? 0 : 180;
            Instantiate(bulletPrefab, barrel.position, Quaternion.Euler(0, 0, zRotation));
            reloadTimer = reloadTime;
        }
    }
}
