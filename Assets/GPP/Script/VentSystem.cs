using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentSystem : MonoBehaviour
{
    public GameObject VentOpen, VentClose;
    public bool IsOpen;


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Interact")) 
        {
            if (!IsOpen)
            {
                IsOpen = true;
                VentOpen.SetActive(true);
                VentClose.SetActive(false);
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
