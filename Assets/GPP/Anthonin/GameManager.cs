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
    //public PlayerController Player;
    public float RespawnTime;

    private void Awake()
    {
        instance = this;
        CurrentCheckpoint = checkpoints[0];
    }

    public void Die()
    {
        Freeze(true);
        Invoke("Respawn", RespawnTime);
    }

    private void Respawn()
    {
        Player.transform.position = CurrentCheckpoint.transform.position;
        Freeze(false); 
    }

    private void Freeze(bool freeze)
    {
        Player.SetSpeed(!freeze);
    }


}