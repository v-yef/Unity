using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRocksController : MonoBehaviour
{
    public GameObject RotateAroundObject;
    public bool IsRotating = false;
	public int DegreesPerSec = 15;
	public int TurnRate = 50;

	// Start is called before the first frame update
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (IsRotating)
        {
	        transform.Rotate (0, TurnRate * Time.deltaTime, 0, Space.World);
        }

        transform.RotateAround(RotateAroundObject.transform.position, Vector3.up, DegreesPerSec * Time.deltaTime);
	}
}