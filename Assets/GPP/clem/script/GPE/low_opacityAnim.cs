using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class low_opacityAnim : MonoBehaviour
{

    public Animator animator;
    public Animation anim;
    private GameObject player;


    public void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
            animator.SetTrigger("Entry");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetTrigger("Exit");
        }
    }
}
