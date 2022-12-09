using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator animator;
   


   

    private void OnTriggerEnter2D(Collider2D collision)
    {                                                                                                                                                                               
        if (collision.gameObject.CompareTag("Electric"))
        {
            
            
            animator.SetTrigger("Door");

        }


    }

  }
