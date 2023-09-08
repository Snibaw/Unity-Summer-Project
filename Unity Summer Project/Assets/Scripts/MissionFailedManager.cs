using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MissionFailedManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    bool canSkip = false;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : "+PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = "HighScore : "+PlayerPrefs.GetInt("HighScore").ToString();
        StartCoroutine(EnableSkip());
    }

    // Update is called once per frame
    void Update()
    {
        if(canSkip && Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    private IEnumerator EnableSkip()
    {
        yield return new WaitForSeconds(1f);
        canSkip = true;
    }
}
