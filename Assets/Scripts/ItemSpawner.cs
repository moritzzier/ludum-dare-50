using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] float _spawnDelay = 1f;
    float _timer = 0;
    float _currentItems;

    [SerializeField] GameObject itemPrefab;
    [SerializeField] Collider2D spawnCollider;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnDelay)
        {
            _timer = 0;
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        Vector3 spawnPoint = spawnCollider.bounds.RandomPointInBounds();
        _ = Instantiate(itemPrefab, spawnPoint, Quaternion.identity);
    }
}
