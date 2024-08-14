using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameStarted;
    public GameObject platformSpawner;

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public GameObject newHighScoreImage;
    public Text lastScoreText;

    [Header("Score")]
    public Text scoreText;
    public Text bestText;
    public Text diamondText;
    public Text starText;

    int score = 0;
    int bestScore, totalDiamond, totalStar;
    bool countScore;


    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Total Diamond
        totalDiamond = PlayerPrefs.GetInt("totalDiamond");
        diamondText.text = totalDiamond.ToString();

        // Total Star
        totalStar = PlayerPrefs.GetInt("totalStar");
        starText.text = totalStar.ToString();

        // Best Score
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestText.text = bestScore.ToString();
    }//Start

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted) 
        {
            if(Input.GetMouseButtonDown(0))     // sol týk yapýldýðýnda oyun baþlar
            {
                GameStart();
            }
        }
    }//Update

    public void GameStart()     //Oyun baþladýðýnda platform yüklenmeye baþlayacak
    { 
        isGameStarted = true;
        countScore = true;
        StartCoroutine(UpdateScore());
        platformSpawner.SetActive(true);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);  //yandýðýnda game over panelini açacak
        lastScoreText.text = score.ToString();
        countScore = false;
        platformSpawner.SetActive(false);

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", score);
            newHighScoreImage.SetActive(true);
        }

    }//GameOver

    IEnumerator UpdateScore()   //UpadateScore
    {
        while(countScore)
        {
            yield return new WaitForSeconds(1f);
            score++;
            if (score > bestScore)
            {
                bestText.text = score.ToString();
            }
                scoreText.text = score.ToString();
            
        }
    }//UpdateScore

    public void ReplayGame() 
    {
        SceneManager.LoadScene("Level");    
    }//ReplayGame

    public void GetStar()
    {
        int newStar = totalStar++;
        PlayerPrefs.SetInt("totalStar", newStar);
        starText.text = totalStar.ToString();   
    }//GetStar

    public void GetDiamond()
    {
        int newDiamond = totalDiamond++;
        PlayerPrefs.SetInt("totalDiamond", newDiamond);
        diamondText.text = totalDiamond.ToString();
    }//GetDiamond

}
