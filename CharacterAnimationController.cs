using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (_playerController.IsOnGround)
        {
            if (_playerController._moveVector.z != 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    playRunAnimation();
                }
                else
                {
                    playWalkAnimation();
                }
            }
            else if (_playerController._moveVector.y > 0)
            {
                playJumpAnimation();
            }
            else
            {
                playIdleAnimation();
            }
        }
        else
        {
            playFallAnimation();
        }
    }

    private void playIdleAnimation() => _animator.SetInteger("State", 0);

    private void playWalkAnimation() => _animator.SetInteger("State", 1);

    private void playRunAnimation() => _animator.SetInteger("State", 2);

    private void playJumpAnimation() => _animator.SetInteger("State", 3);

    private void playFallAnimation() => _animator.SetInteger("State", 4);
}