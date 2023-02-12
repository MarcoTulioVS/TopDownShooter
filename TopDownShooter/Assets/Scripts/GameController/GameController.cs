using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject configurationScreenPanel;

    public ConfigurationsGame config;

    public InputField gameTime;
    public InputField gameSpawnTime;

    public GameObject erroMessagePanel;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void ShowConfigurationScreen()
    {
        configurationScreenPanel.SetActive(true);
    }

    public void SetConfigurations()
    {
        float newGameTime = float.Parse(gameTime.text);
        float newGameSpawnTime = float.Parse(gameSpawnTime.text);

        if ((newGameTime <= 0 || newGameTime>3) || (newGameSpawnTime <= 0 || newGameSpawnTime > 10))
        {
            StartCoroutine("ShowMessagePanel");
        }
        else
        {
            config.TimeMatch = newGameTime;
            config.TimeSpawnEnemy = newGameSpawnTime;
            CloseMenuConfiguration();
        } 
        
    }

    private void CloseMenuConfiguration()
    {
        configurationScreenPanel.SetActive(false);
    }

    IEnumerator ShowMessagePanel()
    {
        erroMessagePanel.SetActive(true);
        CloseMenuConfiguration();
        yield return new WaitForSeconds(5);
        erroMessagePanel.SetActive(false);
        
    }

    public void StartGame(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
