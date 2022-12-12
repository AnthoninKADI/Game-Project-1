using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentScript : MonoBehaviour
{
    [SerializeField]
    public GameObject VentClose, VentOpen;
    public BoxCollider2D Collider;
    private bool IsOpen; 
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Electric") && !IsOpen)
        {
            IsOpen = true;
            VentClose.SetActive(false);
            VentOpen.SetActive(true);
            Collider.enabled = false;
        }

        if (IsOpen)
        {
            IsOpen = false;
            VentClose.SetActive(true);
            VentOpen.SetActive(false);
            Collider.enabled = true;
        }
    }
}
