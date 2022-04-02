using System;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    float _spawnRate = 1f;
    float _timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnRate)
        {
            _timer = 0;
            SpawnItem();
        }

    }
    
    void SpawnItem()
    {
        var values = Enum.GetValues(typeof (Item.ItemType));
        Item.ItemType randomType = (Item.ItemType)values.GetValue(UnityEngine.Random.Range(0, values.Length));

        GameObject item = Instantiate(Resources.Load("Prefabs/Item"), transform.position, Quaternion.identity) as GameObject;
        item.GetComponent<Item>().SetItem(randomType);
    }
}
