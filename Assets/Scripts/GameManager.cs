using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;


public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI coinText;
    private PlayerController playerControllerScript;
    public GameObject aboutPanel;
    public GameObject settingsPanel;
    public GameObject darkPanel;
    public float time;

    private string Url;

    public Button restartButton, mainMenuButton;
    public float timeLeft;
   
   void Start()
    {
        time = 0;
        score = 0;
        timeLeft = 0;
        

        // foodText = "SCORE: " + score;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(CountUp());
       
    }

    void Update()
    {
        


        if (playerControllerScript.gameOver != true)
        {
           // CountUp();
            timeLeft += Time.deltaTime;
            foodText.SetText("Score: " + Mathf.Round(timeLeft));
          
            UpdateCoinCount();
        }
        else
        {
            GameOverPopup();
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        //int timer;
       // timer += Time.deltaTime;
        score += scoreToAdd;
        //scoreText.text = "SCORE: " + score;
    }
    public void UpdateCoinCount()
    {
        
      //  scoreText.text = "SCORE: " + score;
        int coinCount = playerControllerScript.coinCount;
        coinText.text = "" + coinCount;


    }

    public void GameOverPopup()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        darkPanel.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenLinkedin()
    {
        Application.OpenURL("https://www.linkedin.com/in/ugo-som-anene-73156018b/");
    }

    public void CloseAbout()
    {
       aboutPanel.gameObject.SetActive(false);
    }

    public void OpenAbout()
    {
        aboutPanel.gameObject.SetActive(true);
    }

    public void OpenSettings()
    {
        settingsPanel.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.gameObject.SetActive(false);
    }

    IEnumerator CountUp()
    {
        while (playerControllerScript.gameOver != true)
        {
            yield return new WaitForSeconds(1);
            time += 1;
            //scoreText.text = "SCORE: " + time;
            
        }
    }
   
}
