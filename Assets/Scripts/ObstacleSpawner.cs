using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] ObstaclePrefabs;
    [SerializeField] float SpawnRate = 1f;
    [SerializeField] Transform ObstacleParent;
    float spawnWidth = 4f;
    private void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject ObstaclePrefab = ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)];
            Vector2 spawnPos = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(SpawnRate);
            Instantiate(ObstaclePrefab, spawnPos, Random.rotation, ObstacleParent);
        }
    }
}
