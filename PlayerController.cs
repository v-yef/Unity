using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;

    public Vector3 _moveVector;
    public Vector3 _fallVector;

    private float _currentSpeed;
    private float _bonusSpeed;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpHeight;
    public bool IsOnGround { get; private set; }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        computeMovement();
    }

    private void computeMovement()
    {
        IsOnGround = Physics.CheckSphere(transform.position, _groundCheckDistance, _groundMask);

        if (IsOnGround && _fallVector.y < 0)
        {
            _fallVector = Vector3.zero;
        }

        float z = Input.GetAxis("Vertical");

        _moveVector = new Vector3(0, 0, z);
        _moveVector = transform.TransformDirection(_moveVector);

        if (IsOnGround)
        {
            if (_moveVector != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                moveWalk();
            }
            else if (_moveVector != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                moveRun();
            }
            else
            {
                moveIdle();
            }

            if (Input.GetButtonDown("Jump") && _moveVector.z > 0)
            {
                moveJumpForward();
            }

            if (Input.GetButtonDown("Jump"))
            {
                moveJump();
            }

            _moveVector *= _currentSpeed;
        }

        _characterController.Move(_moveVector * Time.deltaTime);

        _fallVector.y += _gravity * Time.deltaTime;
        _characterController.Move(_fallVector * Time.deltaTime);

        if (Input.GetKey("escape"))
        {
            gameQuit();
        }
    }

    private void moveIdle()
    {
        _currentSpeed = 0;
    }

    private void moveWalk()
    {
        _currentSpeed = _walkSpeed + _bonusSpeed;
    }

    private void moveRun()
    {
        _currentSpeed = (_walkSpeed + _bonusSpeed) * 2;
    }

    private void moveJump()
    {
        _fallVector.y = Mathf.Sqrt(_jumpHeight * (-1) * _gravity);
    }

    private void moveJumpForward()
    {
        _fallVector = new Vector3(0, Mathf.Sqrt(_jumpHeight * (-1) * _gravity), Mathf.Sqrt(_jumpHeight * _currentSpeed));
    }

    private void gameQuit()
    {
        SceneManager.LoadScene("Level_0");
    }

    public void SpeedIncrease(float value)
    {
        _bonusSpeed += value;

        Debug.Log("Speed was increased. Current value: " + _currentSpeed);
    }

    public void SpeedDecrease(float value)
    {
        if (_currentSpeed > _walkSpeed)
        {
            _bonusSpeed -= value;

            Debug.Log("Speed was decreased. Current value: " + _currentSpeed);
        }
        else
        {
            Debug.Log("Speed is minimal and can't be decreased!");
        }
    }
}