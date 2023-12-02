using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelfController : MonoBehaviour
{
    [SerializeField] private int _xDegreesPerSec;
    [SerializeField] private int _yDegreesPerSec;
    [SerializeField] private int _zDegreesPerSec;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(
            _xDegreesPerSec * Time.deltaTime,
            _yDegreesPerSec * Time.deltaTime,
            _zDegreesPerSec * Time.deltaTime
            );
    }
}