using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Text CountTimeText;

    private float timeCount;


    void Start()
    {
        timeCount = MenuController.instance.config.TimeMatch * 60;
    }

    
    void Update()
    {
        StartTimeCount();
        
    }

    private void StartTimeCount()
    {
        timeCount -= Time.deltaTime;
        CountTimeText.text = timeCount.ToString();
    }

    private void GameOver()
    {
        if (timeCount <= 0)
        {
            //Exibe tela final
        }
    }


}
