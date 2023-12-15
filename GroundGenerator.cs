using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private int _groundsToFinish;
    private int _groundsCount;

    [SerializeField] private GameObject _groundPrefab;
    [SerializeField] private GameObject _portalPrefab;
    [SerializeField] private int _spawnedOnStartNum;

    private Vector3 _nextSpawnPoint;

    private void Start()
    {
        _groundsCount = 0;

        _nextSpawnPoint = gameObject.transform.position;

        for (int i = 0; i < _spawnedOnStartNum; i++)
        {
            SpawnGround();
        }
    }

    private void Update()
    {

    }

    public void SpawnGround()
    {
        if (_groundsCount < _groundsToFinish)
        {
            GameObject newGround = Instantiate(_groundPrefab, _nextSpawnPoint, Quaternion.identity);
            _nextSpawnPoint = newGround.transform.GetChild(0).transform.position;

            _groundsCount++;
        }
        else
        {
            GameObject newGround = Instantiate(_portalPrefab, _nextSpawnPoint, Quaternion.identity);
            newGround.transform.localScale = new Vector3(15, 15, 1);
        }
    }
}