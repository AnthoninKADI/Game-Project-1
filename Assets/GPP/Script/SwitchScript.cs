using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public Sprite On;
    private door door;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Electric"))
        {
            GetComponent<SpriteRenderer>().sprite = On;
            door.CountSwitch();
        }
    }

    public void SetDoor(door d)
    {
        door = d; 
    }
}
