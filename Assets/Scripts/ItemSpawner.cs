using Assets.Scripts.Utilities;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Collider2D spawnCollider;

    [SerializeField] float _spawnRate = 0f;
    float _timer = 0;

    public void OnSpawnRateUpdate(GameEventArgs gameEventArgs)
    {
        OnSpawnRateUpdateArgs args = (OnSpawnRateUpdateArgs)gameEventArgs;

        _spawnRate = args.newSpawnRate;
    }

    void SpawnItem()
    {
        Vector3 spawnPoint = spawnCollider.bounds.RandomPointInBounds();
        _ = Instantiate(itemPrefab, spawnPoint, Quaternion.identity);
    }
    void Update()
    {
        if (_spawnRate != 0)
        {
            _timer += Time.deltaTime;
            if (_timer >= (1 / _spawnRate))
            {
                _timer = 0;
                SpawnItem();
            }
        }
    }
}
