using Assets.Scripts.Utilities;
using Pixelplacement;
using UnityEngine;
using static Item;

public class CollectItems : MonoBehaviour
{
    [SerializeField] GameEvent onItemCollect;

    [SerializeField] float _pickupSpeed = 0.1f;

    void OnPickup(ItemType itemType)
    {
        onItemCollect.Invoke(new OnItemCollectArgs()
        {
            type = itemType
        });
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            var obj = collision.gameObject;
            var item = obj.GetComponent<Item>();
            if (item == null || !item.IsDragged) return;

            OnPickup(item.Type);

            obj.GetComponent<Rigidbody2D>().isKinematic = true;

            Tween.Position(obj.transform, transform.position, _pickupSpeed, 0, Tween.EaseOut);
            Tween.LocalScale(obj.transform, Vector3.zero, _pickupSpeed, 0, Tween.EaseOut, completeCallback: () => Destroy(obj));
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }
}
