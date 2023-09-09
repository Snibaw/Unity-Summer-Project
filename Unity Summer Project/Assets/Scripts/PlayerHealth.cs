using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 6;
    [SerializeField] private GameObject[] healthIcons;
    public bool isDead = false;
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;
    private SoundEffectManager soundEffectManager;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundEffectManager = GameObject.Find("SoundEffectManager").GetComponent<SoundEffectManager>();
        foreach (var healthIcon in healthIcons)
        {
            healthIcon.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        if(isInvincible) return;
        if(isDead) return;
        soundEffectManager.PlaySoundEffect("playerHit");
        health -= damage;
        healthIcons[health].SetActive(false);
        if (health <= 0)
        {
            isDead = true;
            gameManager.PlayerDie();
        }
        else
        {
            StartCoroutine(Invincible());
        }
    }
    public void AddHealth(int amount)
    {
        if(health + amount > 6)
        {
            health = 6;
        }
        else
        {
            health += amount;
        }
        for(int i=0; i<health; i++)
        {
            healthIcons[i].SetActive(true);
        }
    }
    private IEnumerator Invincible()
    {
        isInvincible = true;
        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
        isInvincible = false;
    }
}
