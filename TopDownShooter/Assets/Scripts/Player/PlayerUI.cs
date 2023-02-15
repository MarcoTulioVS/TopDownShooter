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
        player.Life = player.AuxLife;
        player.Speed = player.AuxSpeed;
        
    }

    
    void Update()
    {
        UpdateLife();
    }

    void UpdateLife()
    {
        lifeAmount.fillAmount = player.Life / 100;


        if (player.Life >= 35 && player.Life < 50)
        {

            AnimationPlayerController.instance.ExecuteAnimation(AnimationStates.HALFLIFE);
        }

        if (player.Life > 0 && player.Life < 35)
        {
            AnimationPlayerController.instance.ExecuteAnimation(AnimationStates.ENDLIFE);
        }

        if (player.Life >= 50 && player.Life <= 100)
        {
            AnimationPlayerController.instance.ExecuteAnimation(AnimationStates.NORMAL);
        }

        if (lifeAmount.fillAmount <= 0)
        {
            lifeAmount.fillAmount = 0;
            player.Speed = 0;
            StartCoroutine("WaitForExplosion");
            
        }
    }

    IEnumerator WaitForExplosion()
    {
        explosion.SetActive(true);
        AnimationPlayerController.instance.ExecuteAnimation(AnimationStates.DEATH);
        yield return new WaitForSeconds(1f);
        GameController.instance.GameOver();
    }
}
