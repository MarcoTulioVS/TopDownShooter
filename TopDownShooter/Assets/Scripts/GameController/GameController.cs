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
       finalScreen.SetActive(true);
        
    }


    private void UpdateScore()
    {
        score.text = scoreValue.ToString();
    }

}
