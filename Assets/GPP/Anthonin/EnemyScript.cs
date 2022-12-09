using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Others")]
    public Collider2D EnemySpotCollider;
    public Animator ShootAnimation;
    public GameObject BlackScreen;
    public GameObject ExclamationMark;

    [Header("Shooting")]
    public float FireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;

    [Header("Player")]
    private Transform player;
    public bool PlayerIsFreeze;
    private PlayerMovement playerMovement;
    //private PlayerHealth playerhealth;
    //private PlayerController playercontroller;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        //float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        //if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        //{
        //    transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        //}
        // if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        //
        // Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
        // nextFireTime = Time.time + FireRate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ExclamationMark.SetActive(true);
            Freeze();
            //Play Shoot Animation after 0.2s
            Invoke("ShootingAnimation", 0.2f);
            //Play Black Screen animation after 1 sec
            Invoke("BlackScreenAnimation", 1f);
            //Kill Player after 1.5 sec
            Invoke("DeathPlayer", 1.5f);
            //Respawn Player on previous checkpoint
        }
    }

    private void Freeze()
    {
        playerMovement.speed = 0;
        //playercontroller.speed = 0;
    }

    private void ShootingAnimation()
    {
        ShootAnimation.enabled = true;
    }

    private void BlackScreenAnimation()
    {
        BlackScreen.SetActive(true);
    }

    private void DeathPlayer()
    {
        // Creer script player Health
       // playerhealth.hp = 0;
    }


}

