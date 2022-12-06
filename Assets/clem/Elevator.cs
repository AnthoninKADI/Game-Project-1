using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Animator animator;
    private GameObject player;



    private void Awake()
    {

        player = GameObject.FindWithTag("Player");


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("moovUp");
        }
            
    }

    
}
