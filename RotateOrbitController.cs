using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOrbitController : MonoBehaviour
{
    [SerializeField] private GameObject _rotateAroundObject;

    [SerializeField] private int _xDegreesPerSec;
    [SerializeField] private int _yDegreesPerSec;
    [SerializeField] private int _zDegreesPerSec;

    [SerializeField] private bool _xRotation;
    [SerializeField] private bool _yRotation;
    [SerializeField] private bool _zRotation;

    void Start()
    {

    }
    
    void Update()
    {
        if (_xRotation)
        {
            transform.RotateAround(
                _rotateAroundObject.transform.position, Vector3.right, _xDegreesPerSec * Time.deltaTime);
        }

        if (_yRotation)
        {
            transform.RotateAround(
                _rotateAroundObject.transform.position, Vector3.up, _yDegreesPerSec * Time.deltaTime);
        }

        if (_zRotation)
        {
            transform.RotateAround(
                _rotateAroundObject.transform.position, Vector3.forward, _zDegreesPerSec * Time.deltaTime);
        }
    }
}