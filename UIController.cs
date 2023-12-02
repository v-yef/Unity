using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    [SerializeField] private TMP_Text _silverCounterText;
    [SerializeField] private TMP_Text _goldCounterText;
    [SerializeField] private TMP_Text _diamondCounterText;

    private SilverCounter _silverCounter;
    private GoldCounter _goldCounter;
    private DiamondCounter _diamondCounter;

    private void Awake()
    {
        _silverCounter = _gameObject.GetComponent<SilverCounter>();
        _goldCounter = _gameObject.GetComponent<GoldCounter>();
        _diamondCounter = _gameObject.GetComponent<DiamondCounter>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if ((null != _silverCounter) && (null != _silverCounterText))
        {
            _silverCounterText.text = _silverCounter.GetCounterValue().ToString();
        }

        if ((null != _goldCounter) && (null != _goldCounterText))
        {
            _goldCounterText.text = _goldCounter.GetCounterValue().ToString();
        }

        if ((null != _diamondCounter) && (null != _diamondCounterText))
        {
            _diamondCounterText.text = _diamondCounter.GetCounterValue().ToString();
        }
    }
}