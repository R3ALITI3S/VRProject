using UnityEngine;
using System.Collections.Generic;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;
    private float nextSpawnTime;

    public float spawnRadius = 2f; // radius around player
    public float minHeight = 0.5f; // min height above player
    public float maxHeight = 2f;   // max height above player
    public float moveSpeed = 1f;

    public Transform playerHeadset; // assign your AR headset transform

    public int maxFruits = 8; // maximum number of fruits at a time
    private List<GameObject> spawnedFruits = new List<GameObject>();

    void Start()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        // Remove destroyed fruits from the list
        spawnedFruits.RemoveAll(item => item == null);

        if (Time.time >= nextSpawnTime)
        {
            if (spawnedFruits.Count < maxFruits)
            {
                SpawnObject();
            }
            SetNextSpawnTime();
        }
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

    void SpawnObject()
    {
        if (playerHeadset == null) return;

        int randomIndex = Random.Range(0, myObjects.Length);

        // Random position in a circle around the player
        float angle = Random.Range(0f, 360f);
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * spawnRadius;
        float z = Mathf.Sin(angle * Mathf.Deg2Rad) * spawnRadius;
        float y = Random.Range(minHeight, maxHeight);

        Vector3 spawnPosition = new Vector3(
            playerHeadset.position.x + x,
            playerHeadset.position.y + y,
            playerHeadset.position.z + z
        );

        GameObject obj = Instantiate(myObjects[randomIndex], spawnPosition, Quaternion.identity);

        // Add movement toward player if needed
        MoveTowardsPlayer mover = obj.AddComponent<MoveTowardsPlayer>();
        mover.player = playerHeadset;
        mover.speed = moveSpeed;

        // Track the spawned fruit
        spawnedFruits.Add(obj);
    }
}
