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

        if(lifeAmount.fillAmount <= 0)
        {
            lifeAmount.fillAmount = 0;
            explosion.SetActive(true);

            //Chama game over
        }
    }
}
