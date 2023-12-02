using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectibleCounter : MonoBehaviour
{
    private int _counterValue;

    private void Start()
    {
        _counterValue = 0;
    }

    private void Update()
    {

    }

    public void IncrementCounter()
    {
        _counterValue++;

        Debug.Log("Counter was increased!");
    }

    public void DecrementCounter()
    {
        if (_counterValue > 0)
        {
            _counterValue--;

            Debug.Log("Counter was decreased!");
        }
        else
        {
            Debug.Log("Counter equals to 0 and can't be decreased!");
        }
    }

    public int GetCounterValue() =>
        _counterValue;
}