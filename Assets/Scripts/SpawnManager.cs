using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject enemyPrefab;
    private float currentTime;
    private float spawnTime = 15f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > spawnTime)
        {
            SpawnEnemy();
            currentTime = 0;
        }
        currentTime += Time.deltaTime;
    }
    private void SpawnEnemy()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoints[i]);
            enemy.transform.position = spawnPoints[i].position;
        }
    }
}
