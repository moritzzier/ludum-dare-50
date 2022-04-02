using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided!");
        
        if (collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
        }
    }
}
