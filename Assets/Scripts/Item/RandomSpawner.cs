using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private int itemCount;
    [SerializeField] private Transform leftLowerBound;
    [SerializeField] private Transform rightUpperBound;
    private Vector3 spawnPos;
    private void Awake()
    {
        itemCount = items.Length;
    }
    private void Start()
    {
        for (int i = 0; i < itemCount; i++)
        {
            spawnPos = new Vector3(Random.Range(leftLowerBound.position.x, rightUpperBound.position.x), 0.3f, Random.Range(leftLowerBound.position.z,rightUpperBound.position.z));
            Instantiate(items[i], spawnPos, Quaternion.identity);
            Debug.Log("Item Spawned No "+ items[i]);
        }
    }
}
