using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Others")]
    [SerializeField]
    private Collider2D EnemySpotCollider;
    [SerializeField]
    private Animator ShootAnimation;
    [SerializeField]
    private GameObject ExclamationMark;
    private float respawnTime;

    public void Start()
    {
        respawnTime = GameManager.instance.respawnTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ExclamationMark.SetActive(true);
            Invoke("ExclamationTime", respawnTime);
            //Play Shoot Animation after 0.2s
            Invoke("ShootingAnimation", 0.2f);
            //Respawn Player on previous checkpoint
        }
    }
    private void ShootingAnimation()
    {
        ShootAnimation.enabled = true;
    }
    private void ExclamationTime()
    {
        ExclamationMark.SetActive(false);
    }
}

