using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyImmoScript : MonoBehaviour
{
    [Header("Others")]
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
            Invoke("ShootingAnimationOff", respawnTime + 1);
            //Play Shoot Animation after 0.2s
            //Respawn Player on previous checkpoint
        }
    }
    private void ShootingAnimation()
    {
        ShootAnimation.SetBool("IsShooting", true);
    }
    private void ShootingAnimationOff()
    {
        ShootAnimation.SetBool("IsShooting", false);
    }

    private void ExclamationTime()
    {
        ExclamationMark.SetActive(false);
    }
}


