using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerHealth playerHealth;
    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            gameManager.IncreaseScore(playerHealth.health*50);
            gameManager.PlayerWin();
        }
    }
}
