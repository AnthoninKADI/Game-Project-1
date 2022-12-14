using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject DoorOpen, DoorClose;
    public bool IsOpen;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Interact"))
        {
            if (!IsOpen)
            {
                IsOpen = true;
                DoorOpen.SetActive(true);
                DoorClose.SetActive(false);
            }
            else if (IsOpen)
            {
                IsOpen = false;
                DoorOpen.SetActive(false);
                DoorClose.SetActive(true);
            }
        }
    }

}
