using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    public Image lifeAmount;
    public Player player;

    public GameObject explosion;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        UpdateLife();
    }

    void UpdateLife()
    {
        lifeAmount.fillAmount = player.Life / 100;
        

        if (player.Life >= 35 && player.Life<50)
        {
            
            AnimationController.instance.ExecuteAnimation(AnimationStates.HALFLIFE);
        }

        if(player.Life > 0 && player.Life < 35)
        {
            AnimationController.instance.ExecuteAnimation(AnimationStates.ENDLIFE);
        }

        if(player.Life >=50 && player.Life <= 100)
        {
            AnimationController.instance.ExecuteAnimation(AnimationStates.NORMAL);
        }

        if(lifeAmount.fillAmount <= 0)
        {
            lifeAmount.fillAmount = 0;
            explosion.SetActive(true);
            AnimationController.instance.ExecuteAnimation(AnimationStates.DEATH);
            //Chama game over
        }
    }
}
