using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour
{
    public Image lifeAmount;

    public Enemy enemy;
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
    }
}
