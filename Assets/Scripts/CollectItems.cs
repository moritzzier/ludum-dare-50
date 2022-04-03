using Pixelplacement;
using UnityEngine;
using static Item;

public class CollectItems : MonoBehaviour
{
    public ItemType RequiredType;
    [SerializeField] private float _pickupSpeed = 0.1f;

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
