using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Others")]
    [SerializeField]
    private Collider2D EnemySpotCollider;
    public Collider2D KillEnemyCollider;
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
            Invoke("ShootingAnimation", 0.2f);
            
            Invoke("ShootingAnimationOff", respawnTime+1);
            //Play Shoot Animation after 0.2s
            
            //Respawn Player on previous checkpoint
        }
    }

    private void ShootingAnimation()
    {
        ShootAnimation.SetBool("IsShooting", true);
        transform.parent.GetComponent<EnemyPatrol>().enabled = false;
    }
    private void ShootingAnimationOff()
    {
        ShootAnimation.SetBool("IsShooting", false);
        transform.parent.GetComponent<EnemyPatrol>().enabled = true;
    }

    private void ExclamationTime()
    {
        ExclamationMark.SetActive(false);
    }
}

