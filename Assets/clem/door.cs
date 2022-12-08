using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator animator;
    private GameObject player;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Electric"))
        {
            //jouer l'anim de la porte qui se leve 
            
            animator.SetTrigger("Door");

        }


    }

  }
