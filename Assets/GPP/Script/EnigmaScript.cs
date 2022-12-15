using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmaScript : MonoBehaviour
{
    public static int totalPlans, currentCount;

    private void Awake()
    {
        totalPlans++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Interact"))
        {
            currentCount++;
            if (currentCount == totalPlans)
            {
                //add Transition new scene
            }
            Destroy(gameObject);
        }
        
    }


    private static void OnSceneChange()
    {
        currentCount = 0;
        totalPlans = 0;
    }
}
