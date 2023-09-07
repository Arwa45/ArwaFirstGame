using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array of obstacle prefabs
    public Transform player; // Reference to the player's transform
    public int maxObstaclesToSpawn = 3; // Maximum number of obstacles to spawn at once
    public float spawnInterval = 2.0f; // Time between obstacle spawns
    public float spawnDistanceAhead = 10.0f; // How far ahead of the player to spawn obstacles

    private float timeSinceLastSpawn = 0.0f;

    private void Start()
    {
        // Initialize the time since last spawn to spawn an obstacle immediately
        timeSinceLastSpawn = spawnInterval;
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObstacles();
            timeSinceLastSpawn = 0.0f;
        }
    }

    private void SpawnObstacles()
    {
        int obstaclesToSpawn = Random.Range(1, maxObstaclesToSpawn + 1);

        for (int i = 0; i < obstaclesToSpawn; i++)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            GameObject obstaclePrefab = obstaclePrefabs[randomIndex];

            // Calculate a random position around the player
            Vector3 spawnPosition = GetRandomSpawnPosition();

            // Instantiate the chosen obstacle at the calculated spawn position
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 playerPosition = player.position;

        // Randomly determine whether to spawn to the left, right, or in front of the player
        float randomX = Random.Range(-1.0f, 1.0f);
        float randomZ = Random.Range(0.0f, 1.0f);

        Vector3 spawnOffset = new Vector3(randomX, 0.0f, randomZ).normalized * spawnDistanceAhead;

        // Calculate the spawn position relative to the player
        Vector3 spawnPosition = playerPosition + spawnOffset;

        return spawnPosition;
    }
}
