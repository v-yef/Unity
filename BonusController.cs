using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    private enum BonusBehaviour
    {
        Undefined,
        SpeedIncrease,
        SpeedDecrease
    };

    private GameObject _player;
    private PlayerController _playerController;
    [SerializeField] private BonusBehaviour _bonusBehaviour;
    [SerializeField] private GameObject _collectedEffect;
    [SerializeField] private AudioClip _collectedSound;
    [SerializeField] private bool _isDestructible;
    [SerializeField] private float _speedIncreaseValue;
    [SerializeField] private float _speedDecreaseValue;

    private void Awake()
    {
        _player = GameObject.Find("Player");
        _playerController = _player.GetComponent<PlayerController>();
    }
    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if ("Player" == other.tag)
        {
            if (null != _playerController)
            {
                switch (_bonusBehaviour)
                {
                    case BonusBehaviour.SpeedIncrease:
                        _playerController.SpeedIncrease(_speedIncreaseValue);
                        break;
                    case BonusBehaviour.SpeedDecrease:
                        _playerController.SpeedDecrease(_speedDecreaseValue);
                        break;
                    case BonusBehaviour.Undefined: // Undefined type must be avoided in the game!!!
                    default:
                        logWarningMessage();
                        break;
                }
            }
            else
            {
                logErrorMessage();
            }

        }

        if (null != _collectedEffect)
        {
            Instantiate(_collectedEffect, transform.position, Quaternion.identity);
        }

        if (null != _collectedSound)
        {
            AudioSource.PlayClipAtPoint(_collectedSound, transform.position);
        }

        if (_isDestructible)
        {
            Destroy(gameObject);
        }
    }

    private void logWarningMessage()
    {
        Debug.LogWarning(
           "WARNING!!! Undefined bonus was collected!!! Must never happen!!!");
    }

    private void logErrorMessage()
    {
        Debug.LogError(
           "ERROR!!! No player controller was detected!!! Can't process the collected bonus!!!");
    }
}