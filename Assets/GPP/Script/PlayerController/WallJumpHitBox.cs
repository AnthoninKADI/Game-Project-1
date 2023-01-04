using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpHitBox : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimation _playerAnimation;
    [SerializeField]
    PlayerController _playerController;
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
        if (collision.gameObject.CompareTag("Wall") && !_playerController.isGrounded)
        {
            if (right)
            {
                _playerController.rightHitbox = true;
            }
            else
            {
                _playerController.leftHitbox = true;
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
                _playerController.rightHitbox = false;
            }
            else
            {
                _playerController.leftHitbox = false;
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
            _playerController.rightHitbox = false;
        }
        else
        {
            _playerController.leftHitbox = false;
        }
        rb.isKinematic = false;
        _playerAnimation.WallJumpingOFF();
    }
}
