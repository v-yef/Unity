using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;

    private Transform parent;

    void Start()
    {
        parent = transform.parent;
    }

    void Update()
    {
        rotate();
    }

    private void rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        
        parent.Rotate(Vector3.up, mouseX);
    }
}