using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [Header("TIME COUNT")]
    public Text CountTimeText;

    private float timeCount;

    [Header("FINAL SCREEN")]
    public GameObject finalScreen;

    public static GameController instance;

    [Header("SCORE")]
    public Text score;

    public float scoreValue;

    public Text finalScore;

    [Header("PAUSE")]
    public GameObject screenPause;

    private bool activeScreenPause;

    public GameObject tutorialMove;
    public GameObject tutorialPause;
    public GameObject tutorialShoot;
    public GameObject background;

    [SerializeField]
    private bool resume;

    private bool stopTutorial;
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
        ResumeGame();

        StartCoroutine("TutorialMove");
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

    IEnumerator TutorialMove()
    {
        if (!stopTutorial)
        {
            if (resume)
            {
                Time.timeScale = 1;
                tutorialMove.SetActive(false);
                background.SetActive(false);
                stopTutorial = true;
                resume = false;
                StopCoroutine("TutorialMove");
            }
            else
            {

                yield return new WaitForSeconds(3);
                background.SetActive(true);
                tutorialMove.SetActive(true);
                Time.timeScale = 0;

            }
        }
        
    }

    public IEnumerator TutorialShoot()
    {
        
        if (resume)
        {
            Time.timeScale = 1;
            
            tutorialShoot.SetActive(false);
            background.SetActive(false);
            yield return new WaitForSeconds(1);
            StopCoroutine("TutorialShoot");
        }
        else
        {
            Time.timeScale = 0;
            tutorialShoot.SetActive(true);
            background.SetActive(true);

        }
    }

    private void ResumeGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            resume = true;
        }
    }
}
