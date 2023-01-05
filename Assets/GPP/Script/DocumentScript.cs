using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class DocumentScript : MonoBehaviour
{
    public Sprite On;
    private DoorDocument doorDocument;
    public GameObject lights;
    public bool transition;
    public GameObject mission2Briefing;
    public GameObject nextMissionButton;
    public string levelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Interact"))
        {
            GetComponent<SpriteRenderer>().sprite = On;
            lights.GetComponent<Light2D>().intensity = 0;
            doorDocument.CountSwitch();
            if (transition)
            {
                mission2Briefing.SetActive(true);
                EventSystem.current.SetSelectedGameObject(nextMissionButton);
            }
        }
    }

    public void SetDoorDocument(DoorDocument y)
    {
        doorDocument = y;
    }

    public void GoLevel2()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}