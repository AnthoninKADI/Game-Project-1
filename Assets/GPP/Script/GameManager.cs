using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private List<GameObject> checkpoints;
    public GameObject CurrentCheckpoint;
    public PlayerController Player;
    public float respawnTime;
    public float BlackScreenAppearAfter;
    public GameObject BlackScreenObject;


    private void Awake()
    {
        instance = this;
        CurrentCheckpoint = checkpoints[0];
    }

    public void Die()
    {
        Freeze(true);
        Invoke("BlackScreenOn", BlackScreenAppearAfter);
        Invoke("Respawn", respawnTime);
    }

    private void Respawn()
    {
        Player.transform.position = CurrentCheckpoint.transform.position;
        Freeze(false);
        Invoke("BlackScreenOff", 2f);
    }

    private void Freeze(bool freeze)
    {
        Player.SetVelocity(!freeze);
    }

    private void BlackScreenOn()
    {
        BlackScreenObject.SetActive(true);
    }

    private void BlackScreenOff()
    {
        BlackScreenObject.SetActive(false);
    }
}