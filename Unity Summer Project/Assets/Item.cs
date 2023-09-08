using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemType;
    private PlayerHealth playerHealth;
    private PlayerShoot playerShoot;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        playerShoot = GameObject.Find("Player").GetComponent<PlayerShoot>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            if(itemType == "Heart")
            {
                playerHealth.AddHealth(2);
                Destroy(gameObject);
            }
            else if(itemType == "Weapon")
            {
                playerShoot.reloadTime = 0.2f;
                Destroy(gameObject);
            }
            else if(itemType == "Score")
            {
                gameManager.SetScoreMultiplierTo2();
                Destroy(gameObject);
            }
        }
    }
}
