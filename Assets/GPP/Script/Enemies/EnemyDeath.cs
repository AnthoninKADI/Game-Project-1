using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Electric"))
        {
            animator.SetBool("IsDead", true);
            Destroy(transform.parent.gameObject);
        }
    }
}
