using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Text CountTimeText;

    private float timeCount;

    public GameObject finalScreen;

    public static GameController instance;

    public Text score;

    public float scoreValue;

    public Text finalScore;

    public GameObject screenPause;

    private bool activeScreenPause;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreValue = 0;
        score.text = "0";
        Time.timeScale = 1;
        timeCount = MenuController.instance.config.TimeMatch * 60;
    }

    
    void Update()
    {
        StartTimeCount();
        UpdateScore();
        PauseGame();
    }

    private void StartTimeCount()
    {
        timeCount -= Time.deltaTime;

        if(timeCount <= 0)
        {
            GameOver();
        }

        CountTimeText.text = timeCount.ToString();
    }

    public void GameOver()
    {
       Time.timeScale = 0;
       finalScore.text = score.text;
       finalScreen.SetActive(true);
        
    }


    private void UpdateScore()
    {
        score.text = scoreValue.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activeScreenPause = !activeScreenPause;
            screenPause.SetActive(activeScreenPause);

            if (activeScreenPause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        
    }
}
