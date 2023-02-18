using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour
{
    [Header("CONTROL LIFE BAR")]
    public Image lifeAmount;

    [Header("ENEMY CONFIGURATION REFERENCE")]
    public Enemy enemy;

    [Header("OBJECT EXPLOSION")]
    public GameObject explosion;

    //[Header("ANIMATION")]
    private Animator anim;

    private float life;

    public float Life { get { return this.life; } set { this.life = value; } }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        enemy.CurrentLife = enemy.Life;
        life = enemy.CurrentLife;
    }

    
    void Update()
    {
        UpdateLife();
       
    }

    private void UpdateLife()
    {
        lifeAmount.fillAmount = life / enemy.Life;
       
        if (lifeAmount.fillAmount > 0.5f)
        {
            anim.SetInteger("transition", 0);
            
        }

        if (lifeAmount.fillAmount > 0 && lifeAmount.fillAmount <= 0.5f)
        {
            anim.SetInteger("transition", 1);

        }



        if (lifeAmount.fillAmount <= 0)
        {
            
            lifeAmount.fillAmount = 0;
            explosion.SetActive(true);
            anim.SetInteger("transition", 2);
            Destroy(gameObject, 0.4f);

        }
    }
}
