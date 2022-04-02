using System;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public static class Extensions
{
    public static Vector3 RandomPointInBounds(this Bounds bounds)
    {
        return new Vector3(
            UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
            UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
            UnityEngine.Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    public static ItemType GetRandomType(this Type type)
    {
        if (!typeof(ItemType).IsEnum) throw new ArgumentException("T must be an enumerated type");

        var values = Enum.GetValues(typeof(ItemType));
        var random = UnityEngine.Random.Range(0, values.Length);
        var t = values.GetValue(random);
        return (ItemType)values.GetValue(random);
    }

    public static GameObject GetParent(this Collider2D collider)
    {
        return collider.transform.parent.gameObject;
    }

    public static void SetPolygonColliderToSpriteBounds(this PolygonCollider2D collider)
    {
        if (!collider.gameObject.GetFirstActiveChild(out var child)) return;

        var sprite = child.GetComponent<SpriteRenderer>().sprite;
        int shapeCount = sprite.GetPhysicsShapeCount();
        collider.pathCount = shapeCount;
        var points = new List<Vector2>(64);
        for (int i = 0; i < shapeCount; i++)
        {
            sprite.GetPhysicsShape(i, points);
            collider.SetPath(i, points);
        }
    }

    public static bool GetFirstActiveChild(this GameObject gameObject, out GameObject child)
    {
        try
        {
            GameObject firstActiveGameObject = null;

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                var c = gameObject.transform.GetChild(i).gameObject;

                if (c.activeSelf == true)
                {
                    firstActiveGameObject = c;
                }
            }
            child = firstActiveGameObject;
            if (child != null)
            {
                return true;
            }
            return false;
        }
        catch (Exception)
        {
            child = null;
            return false;
        }
    }
}
