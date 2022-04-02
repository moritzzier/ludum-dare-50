using Assets.Scripts.Utils;
using System;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    float _spawnDelay = 1f;
    float _timer = 0;
    float _currentItems;

    [SerializeField] GameObject itemPrefab;
    [SerializeField] Collider2D spawnCollider;
    void Start()
    {
        
    }

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
        var values = Enum.GetValues(typeof (Item.ItemType));
        Item.ItemType randomType = (Item.ItemType)values.GetValue(UnityEngine.Random.Range(0, values.Length));

        Vector3 spawnPoint = Utilities.RandomPointInBounds(spawnCollider.bounds);

        GameObject item = Instantiate(itemPrefab, spawnPoint, Quaternion.identity);
        item.GetComponent<Item>().SetItem(randomType);
    }
}
