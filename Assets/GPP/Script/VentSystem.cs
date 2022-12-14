using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentSystem : MonoBehaviour
{
    public GameObject VentOpen, VentClose;
    public bool IsOpen;


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) 
        {
            if (!IsOpen)
            {
                IsOpen = true;
                VentOpen.SetActive(true);
                VentClose.SetActive(false);
                Debug.Log("Electric Collision");
            }
            else if(IsOpen)
            {
                 IsOpen = false;
                 VentOpen.SetActive(false);
                 VentClose.SetActive(true);
            }
        }
    }
}
