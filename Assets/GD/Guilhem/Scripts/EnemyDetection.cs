using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [Header("Others")]
    [SerializeField]
    private Animator EnemyImmobileAnimator;
    [SerializeField]
    private GameObject ExclamationMark;
    private float respawnTime;

    void Start()
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
            Invoke("ShootingAnimationOff", respawnTime + 1);
            //Play Shoot Animation after 0.2s
            //Respawn Player on previous checkpoint
        }
    }
    private void ShootingAnimation()
    {
        EnemyImmobileAnimator.SetBool("IsShooting", true);
    }
    private void ShootingAnimationOff()
    {
        EnemyImmobileAnimator.SetBool("IsShooting", false);
    }

    private void ExclamationTime()
    {
        ExclamationMark.SetActive(false);
    }
}
