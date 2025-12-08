using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetSpawner;
    [SerializeField] private Transform upperRightbound;
    [SerializeField] private Transform lowerLeftbound;
    private Vector3 SpawnPos;

    [SerializeField] List<GameObject> spawnedTargets = new List<GameObject>();
    public void SpawnTargets()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnPos = new Vector3(Random.Range(lowerLeftbound.position.x, upperRightbound.position.x), 0, Random.Range(lowerLeftbound.position.z, upperRightbound.position.z));
            while(OverlappingCheck(SpawnPos))
            {
                SpawnPos = new Vector3(Random.Range(lowerLeftbound.position.x, upperRightbound.position.x), 0, Random.Range(lowerLeftbound.position.z, upperRightbound.position.z));
            }
            GameObject spawnedTarget = Instantiate(targetSpawner, SpawnPos, Quaternion.identity);
            spawnedTargets.Add(spawnedTarget);
        }
    }
    bool OverlappingCheck(Vector3 pos)
    {
        foreach (var target in spawnedTargets)
        {
            if (Vector3.Distance(target.transform.position, pos) < 2.0f)
            {
                return true;
            }
        }
        return false;
    }
    public void DestroyTargets()
    {
        foreach (var target in spawnedTargets)
        {
            Destroy(target);
        }
        spawnedTargets.Clear();
    }

}
