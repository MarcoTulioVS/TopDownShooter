using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Text CountTimeText;

    private float timeCount;

    public GameObject finalScreen;

    public Player player;

    public static GameController instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1;
        timeCount = MenuController.instance.config.TimeMatch * 60;
    }

    
    void Update()
    {
        StartTimeCount();
        
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

    
}
