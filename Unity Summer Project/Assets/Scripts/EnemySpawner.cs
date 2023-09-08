using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private Transform camPos;
    private bool canSpawnEnter = true, canSpawnExit = true;
    // Start is called before the first frame update
    void Start()
    {
        camPos = Camera.main.transform;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && canSpawnEnter)
        {
            if(transform.position.x > camPos.position.x)
            {
                canSpawnEnter = false;
                SpawnEnemy();
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && canSpawnExit)
        {
            if(transform.position.x < camPos.position.x)
            {
                canSpawnExit = false;
                SpawnEnemy();
            }
            
        }
    }
    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.transform.parent = transform;
    }
}
