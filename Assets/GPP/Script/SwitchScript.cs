using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SwitchScript : MonoBehaviour
{
    public Sprite On;
    private door door;
    public GameObject lights;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Interact"))
        {
            GetComponent<SpriteRenderer>().sprite = On;
            door.CountSwitch();
            lights.GetComponent<Light2D>().intensity = 0;
        }
    }

    public void SetDoor(door d)
    {
        door = d; 
    }
}
