using UnityEngine;
using static Item;

public class CollectItems : MonoBehaviour
{
    public ItemType RequiredType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            var obj = collision.gameObject;
            var item = obj.GetComponent<Item>();
            if (item == null || !item.IsDragged) return;

            if (item.Type == RequiredType)
            {
                //+1
                Debug.Log("<color=#00ff00>+1</color>");
            }
            else
            {
                //-1
                Debug.Log("<color=#ff0000>-1</color>");
            }

            Destroy(obj);
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }
}
