using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetSpawner;
    private Vector3 SpawnPos;

    [SerializeField] List<GameObject> spawnedTargets = new List<GameObject>();
    public void SpawnTargets()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnPos = new Vector3(Random.Range(-4.5f, 4.5f), 0, Random.Range(-3.6f, -1.8f));
            GameObject spawnedTarget = Instantiate(targetSpawner, SpawnPos, Quaternion.identity);
            spawnedTargets.Add(spawnedTarget);
        }
    }
    public void DestroyTargets()
    {
        foreach (var target in spawnedTargets)
        {
            Destroy(target);
        }
    }

}
