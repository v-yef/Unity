using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _animator;

    private Vector3 _moveVector;
    private Vector3 _fallVector;

    private float _moveSpeed;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;

    [SerializeField] private float _gravity;
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpHeight;
    private bool _isOnGround;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();

#if !(UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.unityLogger.logEnabled = false;
#endif
    }

    private void Start()
    {

    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        _isOnGround = Physics.CheckSphere(transform.position, _groundCheckDistance, _groundMask);

        if (_isOnGround && _fallVector.y < 0)
        {
            _fallVector.y = -1.0f;
        }

        float z = Input.GetAxis("Vertical");

        _moveVector = new Vector3(0, 0, z);
        _moveVector = transform.TransformDirection(_moveVector);

        if (_isOnGround)
        {
            if (_moveVector != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                walk();
            }
            else if (_moveVector != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                run();
            }
            else
            {
                idle();
            }

            _moveVector *= _moveSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump();
            }
        }
        else
        {

        }

        _characterController.Move(_moveVector * Time.deltaTime);

        _fallVector.y += _gravity * Time.deltaTime;
        _characterController.Move(_fallVector * Time.deltaTime);

        if (Input.GetKey("escape"))
        {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }

    private void idle()
    {
        _animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void walk()
    {
        _moveSpeed = _walkSpeed;

        _animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void run()
    {
        _moveSpeed = _runSpeed;

        _animator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void jump()
    {
        _fallVector.y = Mathf.Sqrt(_jumpHeight * (-1) * _gravity);

        //_animator.SetTrigger("Jump");
    }
}