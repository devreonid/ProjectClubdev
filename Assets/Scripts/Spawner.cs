using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject meteorPrefab;
    public float spawnInterval = 1f;
    public float spawnRangeX = 7f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        GameObject prefabToSpawn = Random.value > 0.3f ? starPrefab : meteorPrefab;
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPos = new Vector2(randomX, transform.position.y);
        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}