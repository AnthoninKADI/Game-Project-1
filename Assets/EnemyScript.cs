using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Others")]
    public Collider2D EnemySpotCollider;
    public Animator ShootAnimation;
    public Animator ScreenAnimation;

    [Header("Shooting")]
    public float FireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;

    [Header("Player")]
    private Transform player;
    public bool PlayerIsFreeze;
    private PlayerMovement playerMovement;


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
            Freeze();
            //Play Shoot Animation after 0.2s
            //Play Black Screen animation
            //Kill Player when black screen is full screen
            //Respawn Player on previous checkpoint
        }
    }

    private void Freeze()
    {
        playerMovement.speed = 0;
    }

    private void ShootingAnimation()
    {
        ShootAnimation.enabled = true;
    }

    private void BlackScreenAnimation()
    {
        ScreenAnimation.enabled = true;
    }
}

