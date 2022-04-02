using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag("Item"))
        {
            Destroy(obj);
        }
    }
}
