using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentScript : MonoBehaviour
{
    public Animator animator;
    public GameObject Vent;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            Vent = collision.gameObject;
        }
    }
}
