using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private PlayerController _playerController;

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

    public void Attack()
    {
        if (_playerController.movementInput.x != 0 && _playerController.ElectricityActive)
        {
            _animator.SetBool("IsRunAttacking", true);
        }
        else if (_playerController.movementInput.x == 0 && _playerController.ElectricityActive)
        {
            _animator.SetBool("IsIdleAttacking", true);
        }
        else
        {
            _animator.SetBool("IsRunAttacking", false);
            _animator.SetBool("IsIdleAttacking", false);
        }
    }

    //public void Jumping()
    //{
    //    if (_playerController.isHolding)
    //    {
    //        _animator.SetBool("IsJumping", true);
    //    }
    //    else
    //    {
    //        _animator.SetBool("IsJumping", false);
    //    }
    //}

    //public void FallingLanding()
    //{
    //    if (_playerController.isGrounded)
    //    {
    //        _animator.SetBool("IsFalling", false);
    //        _animator.SetBool("IsLanded", true);
    //    }
    //    else
    //    {
    //        _animator.SetBool("IsFalling", true);
    //        _animator.SetBool("IsLanded", false);
    //    }
    //}

    //public void WallJumping()
    //{
    //    if (_playerController.hasWallJumped)
    //    {
    //        _animator.SetBool("IsOnWall", true);
    //    }
    //    else
    //    {
    //        _animator.SetBool("IsOnWall", false);
    //    }
    //}
}
