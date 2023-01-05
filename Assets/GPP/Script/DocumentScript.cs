using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DocumentScript : MonoBehaviour
{
    public Sprite On;
    private DoorDocument doorDocument;
    public GameObject lights;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Interact"))
        {
            GetComponent<SpriteRenderer>().sprite = On;
            doorDocument.CountSwitch();
            lights.GetComponent<Light2D>().intensity = 0;
        }
    }

    public void SetDoorDocument(DoorDocument y)
    {
        doorDocument = y;
    }
}
