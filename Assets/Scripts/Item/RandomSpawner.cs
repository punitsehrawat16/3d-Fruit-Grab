using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private int itemCount;
    private Vector3 spawnPos;
    private void Awake()
    {
        itemCount = items.Length;
    }
    private void Start()
    {
        for (int i = 0; i < itemCount; i++)
        {
            spawnPos = new Vector3(Random.Range(4.5f, -4.5f), 0.3f, Random.Range(-9.3f, -10.5f));
            Instantiate(items[i], spawnPos, Quaternion.identity);
            Debug.Log("Item Spawned No "+ items[i]);
        }
    }
}
