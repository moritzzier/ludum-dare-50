using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class Utilities
    {
        public static Vector3 RandomPointInBounds(Bounds bounds)
        {
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }
    }
}