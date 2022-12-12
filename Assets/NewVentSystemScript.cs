using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVentSystemScript : MonoBehaviour
{
    public GameObject VentOpen, VentClose;
    public BoxCollider2D ColliderVent;
    public bool IsOpen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!IsOpen)
            {
                VentOpen.SetActive(false);
                VentClose.SetActive(true);
                IsOpen = true;
            }
            else if (IsOpen)
            {
                VentClose.SetActive(false);
                VentOpen.SetActive(true);
                IsOpen = false;
            }
        }   
    }
}
