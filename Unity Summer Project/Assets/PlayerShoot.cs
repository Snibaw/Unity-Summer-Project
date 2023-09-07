using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform barrel;
    [SerializeField] private float reloadTime = 0.5f;
    private float reloadTimer;
    // Start is called before the first frame update
    void Start()
    {
        reloadTimer = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        reloadTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (reloadTimer < 0)
            {
                GameObject bulletSpawned = Instantiate(bulletPrefab, barrel.position, Quaternion.identity);
                bulletSpawned.GetComponent<BulletBehaviour>().direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
                reloadTimer = reloadTime;
            }
        }
    }
}
