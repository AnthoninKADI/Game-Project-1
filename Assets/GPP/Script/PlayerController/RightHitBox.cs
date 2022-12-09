using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHitBox : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    Rigidbody2D rb;
    private float gravityScale;

    public void Start()
    {
        gravityScale = rb.gravityScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerController.rightHitbox = true;
            rb.gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerController.rightHitbox = false;
            rb.gravityScale = gravityScale;
        }
    }
}
