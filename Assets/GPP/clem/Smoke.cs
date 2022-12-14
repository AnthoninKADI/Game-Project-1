using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    private GameObject player;
   

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //tuer le player, lancer l'anim de whip noir et retour au checkpoint

            GameManager.instance.Die();

            

        }
        

        
    }




}
