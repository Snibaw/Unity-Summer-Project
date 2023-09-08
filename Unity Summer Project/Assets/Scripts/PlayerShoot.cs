using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public Transform[] barrels;
    public Transform barrel;
    public float reloadTime = 0.5f;
    private float reloadTimer;
    private Vector2 direction;
    private float zRotation;
    private bool isLookingDown = false;
    private bool isLookingUp = false;
    // Start is called before the first frame update
    void Start()
    {
        reloadTimer = reloadTime;
        barrel = barrels[0];
    }

    // Update is called once per frame
    void Update()
    {
        reloadTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button1))
        {
            if (reloadTimer < 0)
            {
                if(isLookingDown)
                {
                    zRotation = -90;
                }
                else if(isLookingUp)
                {
                    zRotation = 90;
                }
                else
                {
                    zRotation = transform.localScale.x > 0 ? 0 : 180;
                }

                Instantiate(bulletPrefab, barrel.position, Quaternion.Euler(0, 0, zRotation));
                reloadTimer = reloadTime;
            }
        }
    }
    public void ChangeBarrel(int i)
    {
        barrel = barrels[i];
        isLookingUp = i == 1;
        isLookingDown = i == 2;
        
    }
}
