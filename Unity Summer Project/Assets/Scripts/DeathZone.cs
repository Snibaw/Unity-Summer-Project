using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private GameManager gamaManager;
    // Start is called before the first frame update
    void Start()
    {
        gamaManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            gamaManager.PlayerDie();
        }
    }
}
