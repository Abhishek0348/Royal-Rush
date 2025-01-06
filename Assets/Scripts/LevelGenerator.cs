using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject ChunckPrefab;
    [SerializeField] Transform ChunckParent;
    [SerializeField] float StartingChunckCount = 12f;
    [SerializeField] float ChunckLength = 10f;
    [SerializeField] float moveSpeed = 8f; 

    List<GameObject> Chuncks = new List<GameObject>();

    private void Start()
    {
        SpawnStartingChuncks();
    }

    void Update()
    {
        MoveChuncks();
    }

    private void SpawnStartingChuncks()
    {
        for (int i = 0; i < StartingChunckCount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnChuncksZ();

        Vector3 ChunckSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunck = Instantiate(ChunckPrefab, ChunckSpawnPos, Quaternion.identity, ChunckParent);

        Chuncks.Add(newChunck);
        // OR you can use this
        //transform.position = new Vector3(0, 0, transform.position.z + ChunckLength);
    }

    private float CalculateSpawnChuncksZ()
    {
        float spawnPositionZ;
        if (Chuncks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            //spawnPositionZ = transform.position.z + (i * ChunckLength);
            spawnPositionZ = Chuncks[Chuncks.Count - 1].transform.position.z + ChunckLength;
        }

        return spawnPositionZ;
    }


    private void MoveChuncks()
    {
        for (int i = 0; i < Chuncks.Count; i++)
        {
            GameObject currentChunck = Chuncks[i];
            currentChunck.transform.Translate(-Vector3.forward * (moveSpeed * Time.deltaTime));

            if(currentChunck.transform.position.z <= Camera.main.transform.position.z - ChunckLength)
            {
                Chuncks.Remove(currentChunck);
                Destroy(currentChunck);
                SpawnChunk();
            }
        }
    }
}
