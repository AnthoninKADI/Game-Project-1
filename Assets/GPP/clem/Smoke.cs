using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    private GameObject player;
    SpriteRenderer mysprite;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        mysprite = player.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //tuer le player, lancer l'anim de whip noir et retour au checkpoint
            //GameManager.instance.Die();

            mysprite.color = new Color(255, 163, 0, 0);

        }
        

        
    }




}
