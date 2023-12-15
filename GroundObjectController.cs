using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObjectController : MonoBehaviour
{
    private GroundGenerator _groundGenerator;
    [SerializeField] private int _collectiblesNum;
    [SerializeField] private GameObject[] _collectibles;
    [SerializeField] private Transform[] _collectibleSpawnPoints;

    [SerializeField] private int _bonusesNum;
    [SerializeField] private GameObject[] _bonuses;
    [SerializeField] private Transform[] _bonusSpawnPoints;


    private void Awake()
    {
        _groundGenerator = GameObject.FindObjectOfType<GroundGenerator>();
    }

    private void Start()
    {
        spawnCollectibles();
        spawnBonuses();
    }

    private void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        _groundGenerator.SpawnGround();

        Destroy(gameObject, 1.0f);
    }

    void spawnCollectibles()
    {
        bool[] usedPoints = new bool[_collectibleSpawnPoints.Length];

        for (int i = 0; i < _collectiblesNum; i++)
        {
            int SpawnPointIndex = UnityEngine.Random.Range(0, _collectibleSpawnPoints.Length);

            if (usedPoints[SpawnPointIndex] == false)
            {
                int SpawnPrefab = UnityEngine.Random.Range(0, _collectibles.Length);

                GameObject newCollectible = Instantiate(
                    _collectibles[SpawnPrefab],
                    _collectibleSpawnPoints[SpawnPointIndex].transform.position,
                    Quaternion.identity);

                newCollectible.transform.parent = _collectibleSpawnPoints[SpawnPointIndex].transform;

                usedPoints[SpawnPointIndex] = true;
            }
        }
    }

    private void spawnBonuses()
    {
        bool[] usedPoints = new bool[_bonusSpawnPoints.Length];

        for (int i = 0; i < _bonusesNum; i++)
        {
            int SpawnPointIndex = UnityEngine.Random.Range(0, _bonusSpawnPoints.Length);

            if (usedPoints[SpawnPointIndex] == false)
            {
                int SpawnPrefab = UnityEngine.Random.Range(0, _bonuses.Length);

                GameObject newBonus = Instantiate(
                    _bonuses[SpawnPrefab],
                    _bonusSpawnPoints[SpawnPointIndex].transform.position,
                    Quaternion.identity);

                newBonus.transform.parent = _bonusSpawnPoints[SpawnPointIndex].transform;

                usedPoints[SpawnPointIndex] = true;
            }
        }
    }
}