using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tele : MonoBehaviour
{
    [Header("Prefab & Spawn Points")]
    [SerializeField] private GameObject[] itemPrefabs;  // Các prefab vật phẩm
    [SerializeField] private Transform[] spawnPoints;   // Các vị trí xuất hiện

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 5f;  // Khoảng thời gian giữa các lần sinh vật phẩm
    [SerializeField] private float itemLifetime = 10f;  // Thời gian tồn tại của vật phẩm

    private void Start()
    {
        if (itemPrefabs == null || itemPrefabs.Length == 0)
        {
            Debug.LogError("ItemSpawner: Không có itemPrefab nào được gán!");
            return;
        }

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("ItemSpawner: Không có spawnPoint nào được gán!");
            return;
        }

        InvokeRepeating(nameof(SpawnItem), 0f, spawnInterval);
    }

    private void SpawnItem()
    {
        int itemIndex = Random.Range(0, itemPrefabs.Length);
        int pointIndex = Random.Range(0, spawnPoints.Length);

        GameObject selectedItem = itemPrefabs[itemIndex];
        Transform selectedPoint = spawnPoints[pointIndex];

        if (selectedItem == null || selectedPoint == null)
        {
            Debug.LogWarning("ItemSpawner: Item hoặc Point được chọn đang bị null.");
            return;
        }

        GameObject spawnedItem = Instantiate(selectedItem, selectedPoint.position, Quaternion.identity);
        Destroy(spawnedItem, itemLifetime);
    }
}