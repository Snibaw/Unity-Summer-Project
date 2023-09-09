using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundEffects;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySoundEffect(string soundEffectName)
    {
        switch (soundEffectName)
        {
            case "playerHit":
                audioSource.PlayOneShot(soundEffects[0]);
                break;
            case "jump":
                audioSource.PlayOneShot(soundEffects[1]);
                break;
            case "playerShoot":
                audioSource.PlayOneShot(soundEffects[2]);
                break;
            case "enemyShoot":
                audioSource.PlayOneShot(soundEffects[3]);
                break;
            case "item":
                audioSource.PlayOneShot(soundEffects[4]);
                break;
        }
    }
}
