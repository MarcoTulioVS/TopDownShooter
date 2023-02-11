using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    public Image lifeAmount;
    public Player player;

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
    }
}
