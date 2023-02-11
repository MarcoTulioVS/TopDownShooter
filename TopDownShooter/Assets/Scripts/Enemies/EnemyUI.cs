using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour
{
    public Image lifeAmount;

    public Enemy enemy;

    public GameObject explosion;
    void Start()
    {
        enemy.CurrentLife = enemy.Life;
    }

    
    void Update()
    {
        UpdateLife();
    }

    private void UpdateLife()
    {
        lifeAmount.fillAmount = enemy.CurrentLife / enemy.Life;

        if(lifeAmount.fillAmount <= 0)
        {
            lifeAmount.fillAmount = 0;
            explosion.SetActive(true);
        }
    }
}
