using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpHitBox : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimation _playerAnimation;
    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    Rigidbody2D rb;
    private float gravityScale;
    [SerializeField]
    private float timeToFall;
    [SerializeField]
    bool right;

    public void Start()
    {
        gravityScale = rb.gravityScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (right)
            {
                playerController.rightHitbox = true;
            }
            else
            {
                playerController.leftHitbox = true;
            }
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            _playerAnimation.WallJumpingON();
            Invoke("PlayerFalling", timeToFall);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (right)
            {
                playerController.rightHitbox = false;
            }
            else
            {
                playerController.leftHitbox = false;
            }
            rb.isKinematic = false;
            _playerAnimation.WallJumpingOFF();
            CancelInvoke();
        }
    }

    private void PlayerFalling()
    {
        if (right)
        {
            playerController.rightHitbox = false;
        }
        else
        {
            playerController.leftHitbox = false;
        }
        rb.isKinematic = false;
    }
}
