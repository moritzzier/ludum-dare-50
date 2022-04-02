using UnityEngine;

public class CollectItems : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        //if (!obj.GetComponent<Item>().IsDragged) return;

        if (obj.CompareTag("Item"))
        {
            Destroy(obj);
        }
    }
}
