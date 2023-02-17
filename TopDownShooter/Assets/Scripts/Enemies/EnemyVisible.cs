using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisible : MonoBehaviour
{
    private bool isVisible;
    private bool stopCoroutines;
    private void OnBecameVisible()
    {
        isVisible = true;
        
    }

    private void Update()
    {
        if (!stopCoroutines)
        {
            if (isVisible)
            {
                StartCoroutine(GameController.instance.TutorialShoot());
                StartCoroutine("DesactiveVisible");
            }
        }
    }

    IEnumerator DesactiveVisible()
    {
        yield return new WaitForSeconds(1);
        stopCoroutines = true;
    }
}
