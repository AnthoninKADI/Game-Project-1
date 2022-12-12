using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> checkpoints;
    public GameObject CurrentCheckpoint;
    public PlayerMovement Player;
    public EnemyScript enemyScript;
    //public PlayerController Player;
    public float RespawnTime;
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
        Invoke("Respawn", RespawnTime);
    }

    private void Respawn()
    {
        Player.transform.position = CurrentCheckpoint.transform.position;
        Freeze(false);
        ExclamationTime();
        Invoke("BlackScreenOff", 2f);
    }

    private void Freeze(bool freeze)
    {
        Player.SetSpeed(!freeze);
    }

    private void BlackScreenOn()
    {
        BlackScreenObject.SetActive(true);
    }

    private void BlackScreenOff()
    {
        BlackScreenObject.SetActive(false);
    }

    private void ExclamationTime()
    {
        enemyScript.ExclamationMark.SetActive(false);
        Debug.Log("test");
    }


    


}