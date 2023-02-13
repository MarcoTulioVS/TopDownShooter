using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour
{
    public Image lifeAmount;

    public Enemy enemy;

    public GameObject explosion;

    public Animator anim;

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


        if (enemy.CurrentLife >= 35 && enemy.CurrentLife < 50)
        {
            anim.SetInteger("transition", 1);
            
        }

        if (enemy.CurrentLife > 0 && enemy.CurrentLife < 35)
        {
            anim.SetInteger("transition", 2);
            
        }

        if (enemy.CurrentLife >= 50 && enemy.CurrentLife <= 100)
        {
            anim.SetInteger("transition", 0);
            
        }

        

        if (lifeAmount.fillAmount <= 0)
        {
            
            lifeAmount.fillAmount = 0;
            explosion.SetActive(true);
            anim.SetInteger("transition", 3);
            Destroy(gameObject, 0.4f);

        }
    }
}
