using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    float spawnRate = 2f;

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    int poolSize = 5;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(prefab);
            enemy.SetActive(false);
            pool[i] = enemy;
        }
    }

    private void EnableObjectInPool()
    {
        foreach (GameObject enemy in pool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return;
            }
        }
    }

    private IEnumerator SpawnEnemy()
    {

        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
