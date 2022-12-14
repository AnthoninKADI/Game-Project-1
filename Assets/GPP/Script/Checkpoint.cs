using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite CheckpointActive;
    private bool IsActivate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsActivate == true) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CurrentCheckpoint = gameObject;
            IsActivate = true;
            transform.GetComponent<SpriteRenderer>().sprite = CheckpointActive;
        }
    }
}