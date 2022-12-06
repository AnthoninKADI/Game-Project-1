using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> checkpoints;
    public GameObject CurrentCheckpoint;
    public GameObject Player;

    private void Awake()
    {
        instance = this;
        CurrentCheckpoint = checkpoints[0];
    }

    public void Die()
    {
        Player.transform.position = CurrentCheckpoint.transform.position;
    }
}