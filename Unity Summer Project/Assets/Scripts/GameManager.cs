using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public int scoreMultiplier = 1;
    [SerializeField] private GameObject scoreMultiplierIcon;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
        scoreMultiplierIcon.SetActive(false);
    }

    public void IncreaseScore(int score)
    {
        scoreText.text = (int.Parse(scoreText.text) + score*scoreMultiplier).ToString();
    }
    public void PlayerDie()
    {
        PlayerPrefs.SetInt("Score", int.Parse(scoreText.text));
        if (PlayerPrefs.GetInt("HighScore") < int.Parse(scoreText.text))
        {
            PlayerPrefs.SetInt("HighScore", int.Parse(scoreText.text));
        }
        SceneManager.LoadScene("Failed");
    }
    public void PlayerWin()
    {
        PlayerPrefs.SetInt("Score", int.Parse(scoreText.text));
        if (PlayerPrefs.GetInt("HighScore") < int.Parse(scoreText.text))
        {
            PlayerPrefs.SetInt("HighScore", int.Parse(scoreText.text));
        }
        SceneManager.LoadScene("Success");
    }
    public void SetScoreMultiplierTo2()
    {
        scoreMultiplier = 2;
        scoreMultiplierIcon.SetActive(true);
    }
}
