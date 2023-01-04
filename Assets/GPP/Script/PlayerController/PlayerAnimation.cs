using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private PlayerController _playerController;


    private void FixedUpdate()
    {
        Falling();
        Landing();
    }

    public void Running()
    {
        if (_playerController.movementInput.x != 0)
        {
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    public void AttackON()
    {
        if (_playerController.movementInput.x != 0)
        {
            _animator.SetBool("IsRunAttacking", true);
        }
        else if (_playerController.movementInput.x == 0)
        {
            _animator.SetBool("IsIdleAttacking", true);
        }
    }

    public void AttackOFF()
    {
        _animator.SetBool("IsRunAttacking", false);
        _animator.SetBool("IsIdleAttacking", false);
    }

    public void Jumping()
    {
        _animator.SetBool("IsJumping", true);
        _animator.SetBool("IsLanded", false);
    }

    public void Falling()
    {
        if (_animator.GetBool("IsJumping"))
        {
            if (_playerController.rb.velocity.y < 0)
            {
                _animator.SetBool("IsJumping", false);
                _animator.SetBool("IsFalling", true);
            }
        }
    }

    public void Landing()
    {
        if(_playerController.isGrounded)
        {
            _animator.SetBool("IsLanded", true);
            if (_animator.GetBool("IsFalling"))
            {
                _animator.SetBool("IsFalling", false);
            }
        }
    }

    public void WallJumpingON()
    {
        _animator.SetBool("IsOnWall", true);
        _animator.SetBool("IsFalling", false);
        //_playerController.hasWallJumped
    }
    public void WallJumpingOFF()
    {
        _animator.SetBool("IsOnWall", false);
    }
}
