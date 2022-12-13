using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject lightGo;
    private float respawnTime;

    public void Start()
    {
        respawnTime = GameManager.instance.respawnTime;
        lightGo.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lightGo.SetActive(true);
            Invoke("LightOff", respawnTime);
        }
    }

    private void LightOff()
    {
        lightGo.SetActive(false);
    }
}
