using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class low_opacity : MonoBehaviour
{
    private Transform player;
    SpriteRenderer mysprite;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        mysprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            mysprite.color = new Color(0, 0, 0, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            mysprite.color = Color.black;
        }
    }
}
