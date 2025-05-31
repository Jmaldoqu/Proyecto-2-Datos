using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    public GameObject[] TokenPrefabs; // Lista de prefabs diferentes
    public float spawnInterval = 5f;
    public float spawnRangeX = 8f;
    public float spawnHeight = 10f;

    void Start()
    {
        InvokeRepeating("SpawnCoin", 1f, spawnInterval);
    }

    void SpawnCoin()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);

        // Elegir un prefab aleatoriamente
        int index = Random.Range(0, TokenPrefabs.Length);
        GameObject selectedPrefab = TokenPrefabs[index];

        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}
// Update is called once per frame


