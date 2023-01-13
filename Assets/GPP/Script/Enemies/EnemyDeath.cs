using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Animator animator;
    public GameObject DetectionZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Electric"))
        {
            animator.SetBool("IsDead", true);
            DetectionZone.SetActive(false);
            Invoke("DeathEnemy",1.5f);
        }
    }

    private void DeathEnemy()
    {
        Destroy(transform.parent.gameObject);
    }
}
